using KuaforumShared;
using MassTransit;
using Microsoft.Extensions.Logging;
using Serilog.Context;

public sealed class LogMessageConsumer : IConsumer<LogMessage>
{
    private readonly ILogger<LogMessageConsumer> _logger;

    public LogMessageConsumer(ILogger<LogMessageConsumer> logger)
        => _logger = logger;

    public Task Consume(ConsumeContext<LogMessage> ctx)
    {
        var m = ctx.Message;

        using (Serilog.Context.LogContext.PushProperty("user_name", m.UserName ?? "(anonymous)"))
        using (Serilog.Context.LogContext.PushProperty("service_name", m.ServiceName))
        using (Serilog.Context.LogContext.PushProperty("action_name", m.ActionName))
        {
            _logger.LogInformation("Received log message from {Service}: {Action}",
                m.ServiceName, m.ActionName);
        }

        return Task.CompletedTask;
    }
}
