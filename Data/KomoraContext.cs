using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraceabilityVisualization_v2.Models.Traceability;

    public class KomoraContext : DbContext
    {
        public KomoraContext (DbContextOptions<KomoraContext> options)
            : base(options)
        {
        }

        public DbSet<Komora> Komora { get; set; }
    }
