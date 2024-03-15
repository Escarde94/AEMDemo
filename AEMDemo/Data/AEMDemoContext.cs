using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AEMDemo;

namespace AEMDemo.Data
{
    public class AEMDemoContext : DbContext
    {
        public AEMDemoContext (DbContextOptions<AEMDemoContext> options)
            : base(options)
        {
        }

        public DbSet<AEMDemo.PlatformDto> PlatformDto { get; set; } = default!;
        public DbSet<AEMDemo.WellDto> WellDto { get; set; } = default!;
    }
}
