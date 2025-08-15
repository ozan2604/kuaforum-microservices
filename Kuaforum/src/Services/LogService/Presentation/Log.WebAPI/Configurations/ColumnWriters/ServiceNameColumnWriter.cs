using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Log.WebAPI.Configurations.ColumnWriters;

public class ServiceNameColumnWriter : ColumnWriterBase
{
    public ServiceNameColumnWriter() : base(NpgsqlDbType.Varchar)
    {
    }

    public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
    {
        if (logEvent.Properties.TryGetValue("service_name", out var value) && value is ScalarValue sv && sv.Value is string s)
        {
            return s;
        }
        return null;
    }
}
