using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Log.WebAPI.Configurations.ColumnWriters;

public class ActionNameColumnWriter : ColumnWriterBase
{
    public ActionNameColumnWriter() : base(NpgsqlDbType.Varchar)
    {
    }

    public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
    {
        var value = logEvent.Properties.FirstOrDefault(x => x.Key == "action_name").Value;
        return value?.ToString();
    }
}
