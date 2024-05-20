using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Models;

namespace DotNetTask.Data
{
    public class DotNetTaskContext : DbContext
    {
        public DotNetTaskContext (DbContextOptions<DotNetTaskContext> options)
            : base(options)
        {
        }

        public DbSet<ProgramInformation> ProgramInformation { get; set; } = default!;
    }
}
