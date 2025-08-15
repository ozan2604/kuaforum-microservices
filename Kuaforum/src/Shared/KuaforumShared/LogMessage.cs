namespace KuaforumShared;

public class LogMessage
{
    public string? UserName { get; set; }
    public string? ServiceName { get; set; }
    public string? ActionName { get; set; }
    public string? Level { get; set; }
    public string? Message { get; set; }
    public DateTime TimeStamp { get; set; }
}
