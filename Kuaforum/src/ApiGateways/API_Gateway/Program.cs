using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Security.Claims;
using System.Text;
using MassTransit;
using KuaforumShared;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"],
            ushort.Parse(builder.Configuration["RabbitMQ:Port"]), "/", h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var publishEndpoint = context.RequestServices.GetRequiredService<IPublishEndpoint>();
    var username = context.User?.Identity?.IsAuthenticated == true ? context.User.Identity?.Name : null;
    var path = context.Request.Path.Value ?? string.Empty;
    var serviceName = path.Trim('/').Split('/').FirstOrDefault();
    var actionName = $"{context.Request.Method} {path}";

    await publishEndpoint.Publish(new LogMessage
    {
        UserName = username,
        ServiceName = serviceName,
        ActionName = actionName,
        Level = "Information",
        Message = "Gateway request",
        TimeStamp = DateTime.UtcNow
    });

    await next();
});

app.MapControllers();

await app.UseOcelot();
app.Run();
