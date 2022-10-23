using System.ComponentModel.DataAnnotations;

namespace Calculator.Utilities.SQL.Models
{
    public class LogEntry
    {
        [Key]
        public string RequestId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Operation { get; set; }
        public string? Request { get; set; }

        public LogEntry()
        {
            RequestId = Guid.NewGuid().ToString(); 
        }
    }
}
