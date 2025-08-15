using KuaforumShared;
using MassTransit;
using SLog = Serilog.Log;
using Serilog.Context;

namespace Log.WebAPI.Consumers;

public class LogMessageConsumer : IConsumer<LogMessage>
{
    public Task Consume(ConsumeContext<LogMessage> context)
    {
        using (Serilog.Context.LogContext.PushProperty("user_name", context.Message.UserName))
        using (Serilog.Context.LogContext.PushProperty("service_name", context.Message.ServiceName))
        using (Serilog.Context.LogContext.PushProperty("action_name", context.Message.ActionName))
        {
            SLog.Information(context.Message.Message);
        }

        return Task.CompletedTask;
    }
}
