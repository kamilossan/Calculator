namespace Calculator.Utilities.SQL.Models
{
    public class LogEntry
    {
        public DateTime TimeStamp { get; set; }
        public string? Operation { get; set; }
        public string? Request { get; set; }
    }
}
