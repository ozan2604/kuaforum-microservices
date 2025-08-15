using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Log.WebAPI.Configurations.ColumnWriters
{
    public class UsernameColumnWriter : ColumnWriterBase
    {
        public UsernameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            if (logEvent.Properties.TryGetValue("user_name", out var value) && value is ScalarValue sv && sv.Value is string s)
            {
                return s;
            }
            return null;
        }
    }
}
