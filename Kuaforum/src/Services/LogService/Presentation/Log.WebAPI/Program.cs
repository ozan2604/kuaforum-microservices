using Log.WebAPI.Configurations.ColumnWriters;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(log);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated !=null || true ? context.User?.Identity?.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();
