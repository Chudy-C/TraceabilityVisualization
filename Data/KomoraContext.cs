using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraceabilityVisualization_v2.Models;

    public class KomoraContext : DbContext
    {
        public KomoraContext (DbContextOptions<KomoraContext> options)
            : base(options)
        {
        }

        public DbSet<TraceabilityVisualization_v2.Models.Komora> Komora { get; set; }
    }
