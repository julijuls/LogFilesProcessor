using LogsDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDAL.DBContext
{
    public class LogsDbContext : DbContext
    {
        public LogsDbContext(DbContextOptions<LogsDbContext> options) : base(options)
        {
        }

        public DbSet<LogEntity> Logs { get; set; }

    }
}
