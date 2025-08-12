using Log.Persistence;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddHttpContextAccessor();

builder.Services.AddLogPersistenceServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"),"logs",needAutoCreateTable: true,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        { "Message", new RenderedMessageColumnWriter() },
        { "MessageTemplate", new MessageTemplateColumnWriter() },
        { "Level", new LevelColumnWriter() },
        { "TimeStamp", new TimestampColumnWriter() },
        { "Exception", new ExceptionColumnWriter() },
        { "LogEvent", new LogEventSerializedColumnWriter() },
        {"Properties", new PropertiesColumnWriter() },
        {"user_name" , new UsernameColumnWriter() } // Custom column writer for username
    })
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"]) //, apiKey: builder.Configuration["Seq:ApiKey"]
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
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true, // tokený kim daðýtýyor (biz)
            ValidateAudience = true, // tokený kim kullanýyor 
            ValidateLifetime = true, // tokenýn geçerlilik süresi doðrular
            ValidateIssuerSigningKey = true, // tokenýn bizim ürettiðimize dair bir key

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            // tokenýn süresi geçerli mi
            ClockSkew = TimeSpan.Zero, // tokenýn süresi geçerli mi
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(); // Loglanmasýný istediðin middlewarelerin üzerine koy

app.UseHttpLogging(); // HTTP logging middleware
app.UseHttpsRedirection();

app.UseAuthentication(); // kendimiz ekliyoruz
app.UseAuthorization();



app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User?.Identity?.Name : null;

    Serilog.Context.LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();
