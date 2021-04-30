using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraceabilityVisualization_v2.Models.Visualization;

namespace TraceabilityVisualization_v2.Data
{
    public class VisualizationContext : DbContext
    {
        public VisualizationContext(DbContextOptions<VisualizationContext> options)
        : base(options)
        {

        }

        public DbSet<VisualizationLists> VisualizationLists { get; set; }
    }
}
