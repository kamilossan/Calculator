using Calculator.Utilities.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Utilities.SQL
{
    public class DataBaseContext:DbContext
    {
        public DbSet<LogEntry> LogEntries { get; set; }
        private string DbPath { get; set; }

        public DataBaseContext(IConfiguration configuration)
        {
            //can specify custom location in appsettings.json by adding DbPath property
            DbPath = configuration["DbPath"] ?? Path.Join(Directory.GetCurrentDirectory(), "logs.db");
            Console.WriteLine($"SQL database location: {DbPath}");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
