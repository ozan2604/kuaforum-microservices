using Log.WebAPI.Configurations.ColumnWriters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using System.Text;
using MassTransit;
using System.Collections.Generic;
using System.Security.Claims;
using Serilog.Debugging;

var builder = WebApplication.CreateBuilder(args);
SelfLog.Enable(msg =>
    System.IO.File.AppendAllText("serilog-selflog.txt", msg + Environment.NewLine));


builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<LogMessageConsumer>();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"],
            ushort.Parse(builder.Configuration["RabbitMQ:Port"]), "/",
            h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
        cfg.ReceiveEndpoint("log-service", e =>
        {
            e.ConfigureConsumer<LogMessageConsumer>(ctx);
        });
    });
});

Logger log = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs_v2/log.txt") 
    .WriteTo.PostgreSQL(
        connectionString: builder.Configuration.GetConnectionString("PostgreSQL"),
        tableName: "logs_v2",                 
        needAutoCreateTable: true,
        columnOptions: new Dictionary<string, ColumnWriterBase>
        {
            { "message",          new RenderedMessageColumnWriter() },
            { "messagetemplate",  new MessageTemplateColumnWriter() },
            { "level",            new LevelColumnWriter() },
            { "timestamp",        new TimestampColumnWriter() },
            { "exception",        new ExceptionColumnWriter() },
            { "logevent",         new LogEventSerializedColumnWriter() },
            { "properties",       new PropertiesColumnWriter() },
            { "user_name",        new UsernameColumnWriter() },
            { "service_name",     new ServiceNameColumnWriter() },
            { "action_name",      new ActionNameColumnWriter() }
        })
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

builder.Services.AddAuthorization();
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.Name,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();

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
        diag.Set("service_name", "log");
        diag.Set("action_name", $"{ctx.Request.Method} {ctx.Request.Path}");
    };
});



//app.Use(async (context, next) =>
//{
//    var username = context.User?.Identity?.IsAuthenticated == true
//        ? context.User.Identity!.Name
//        : null;

    
//    var serviceName = "log"; 
//    var actionName = $"{context.Request.Method} {context.Request.Path}";

//    using (Serilog.Context.LogContext.PushProperty("user_name", username ?? "(anonymous)"))
//    using (Serilog.Context.LogContext.PushProperty("service_name", serviceName))
//    using (Serilog.Context.LogContext.PushProperty("action_name", actionName))
//    {
//        await next();
//    }
//});




app.UseAuthorization();

app.MapControllers();

app.Run();
