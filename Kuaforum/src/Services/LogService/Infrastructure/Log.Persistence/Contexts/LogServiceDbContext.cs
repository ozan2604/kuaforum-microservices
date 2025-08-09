using Log.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Persistence.Contexts
{
    public class LogServiceDbContext : DbContext
    {
        public LogServiceDbContext(DbContextOptions<LogServiceDbContext> options) : base(options)
        {
        }
         public DbSet<LogEntry> LogEntries { get; set; }

    }
}
