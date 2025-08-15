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
using Log.WebAPI.Consumers;
using System.Collections.Generic;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"),
        "logs", needAutoCreateTable: true,
        columnOptions: new Dictionary<string, ColumnWriterBase>
        {
            { "Message", new RenderedMessageColumnWriter() },
            { "MessageTemplate", new MessageTemplateColumnWriter() },
            { "Level", new LevelColumnWriter() },
            { "TimeStamp", new TimestampColumnWriter() },
            { "Exception", new ExceptionColumnWriter() },
            { "LogEvent", new LogEventSerializedColumnWriter() },
            { "Properties", new PropertiesColumnWriter() },
            { "user_name", new UsernameColumnWriter() },
            { "service_name", new ServiceNameColumnWriter() },
            { "action_name", new ActionNameColumnWriter() }
        })
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
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
app.UseSerilogRequestLogging();

app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated == true ? context.User.Identity?.Name : null;
    using (Serilog.Context.LogContext.PushProperty("user_name", username ?? "(anonymous)"))
    {
        await next();
    }
});

app.MapControllers();

app.Run();
