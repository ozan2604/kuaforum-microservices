using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Serilog;
using SerilogLogContext = Serilog.Context.LogContext;
using MassTransit;
using Notification.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Serilog (delegate imzasý!)
builder.Host.UseSerilog((ctx, services, lc) => lc
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(ctx.Configuration["Seq:ServerUrl"])
);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNotificationServices();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(
            builder.Configuration["RabbitMQ:Host"],
            ushort.Parse(builder.Configuration["RabbitMQ:Port"]),
            "/",
            h =>
            {
                h.Username(builder.Configuration["RabbitMQ:Username"]);
                h.Password(builder.Configuration["RabbitMQ:Password"]);
            });
    });
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (nb, exp, token, p) => exp != null && exp > DateTime.UtcNow,
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.Name,
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Serilog Request Logging (MIDDLEWARE) — doðru yazým ve doðru yer
app.UseSerilogRequestLogging();

app.UseAuthentication();

//app.Use(async (context, next) =>
//{
//    var username = context.User?.Identity?.IsAuthenticated == true
//        ? context.User.Identity!.Name
//        : null;

//    var serviceName = builder.Configuration["Service:Name"] ?? "notification";
//    var actionName = $"{context.Request.Method} {context.Request.Path}";

//    using (SerilogLogContext.PushProperty("user_name", username ?? "(anonymous)"))
//    using (SerilogLogContext.PushProperty("service_name", serviceName))
//    using (SerilogLogContext.PushProperty("action_name", actionName))
//    {
//        await next();
//    }
//});

app.UseSerilogRequestLogging(opts =>
{
    opts.EnrichDiagnosticContext = (diag, ctx) =>
    {
        var name =
            ctx.User?.Identity?.IsAuthenticated == true
                ? (ctx.User.FindFirst(ClaimTypes.Name)?.Value
                    ?? ctx.User.FindFirst("preferred_username")?.Value
                    ?? ctx.User.FindFirst("name")?.Value
                    ?? ctx.User.FindFirst("unique_name")?.Value
                    ?? ctx.User.FindFirst(ClaimTypes.Email)?.Value
                    ?? ctx.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? ctx.User.FindFirst("sub")?.Value)
                : null;

        diag.Set("user_name", name ?? "(anonymous)");
        diag.Set("service_name", "notification");
        diag.Set("action_name", $"{ctx.Request.Method} {ctx.Request.Path}");
    };
});

app.UseAuthorization();

app.MapControllers();

app.Run();
