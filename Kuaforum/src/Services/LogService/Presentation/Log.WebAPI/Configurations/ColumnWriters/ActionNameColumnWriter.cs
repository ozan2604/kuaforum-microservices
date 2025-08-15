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
        if (logEvent.Properties.TryGetValue("action_name", out var value) && value is ScalarValue sv && sv.Value is string s)
        {
            return s;
        }
        return null;
    }
}
