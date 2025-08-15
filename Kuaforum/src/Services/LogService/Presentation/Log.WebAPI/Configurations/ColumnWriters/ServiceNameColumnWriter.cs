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
        var value = logEvent.Properties.FirstOrDefault(x => x.Key == "service_name").Value;
        return value?.ToString();
    }
}
