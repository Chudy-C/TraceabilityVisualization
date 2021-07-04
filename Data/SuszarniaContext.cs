using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraceabilityVisualization_v2.Models.Traceability;

    public class SuszarniaContext : DbContext
    {
        public SuszarniaContext (DbContextOptions<SuszarniaContext> options)
            : base(options)
        {
        }

        public DbSet<TraceabilityVisualization_v2.Models.Traceability.Suszarnia> Suszarnia { get; set; }
    }
