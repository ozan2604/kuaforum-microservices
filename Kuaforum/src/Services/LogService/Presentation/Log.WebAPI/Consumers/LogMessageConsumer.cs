using KuaforumShared;
using MassTransit;
using Serilog;
using Serilog.Context;

namespace Log.WebAPI.Consumers;

public class LogMessageConsumer : IConsumer<LogMessage>
{
    public Task Consume(ConsumeContext<LogMessage> context)
    {
        using (LogContext.PushProperty("user_name", context.Message.UserName))
        using (LogContext.PushProperty("service_name", context.Message.ServiceName))
        using (LogContext.PushProperty("action_name", context.Message.ActionName))
        {
            Log.Information(context.Message.Message);
        }

        return Task.CompletedTask;
    }
}
