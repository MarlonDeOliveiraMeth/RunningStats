using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RunningStats.Models;

namespace RunningStats.Data
{
    public class RunningStatsContext : DbContext
    {
        public RunningStatsContext (DbContextOptions<RunningStatsContext> options)
            : base(options)
        {
        }

        public DbSet<RunningStats.Models.RunningModel> RunningModel { get; set; } = default!;
    }
}
