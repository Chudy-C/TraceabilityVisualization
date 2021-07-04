using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraceabilityVisualization_v2.Models.Traceability;

    public class WozekContext : DbContext
    {
        public WozekContext (DbContextOptions<WozekContext> options)
            : base(options)
        {
        }

        public DbSet<TraceabilityVisualization_v2.Models.Traceability.Wozek> Wozek { get; set; }
    }
