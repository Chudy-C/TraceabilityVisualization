using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraceabilityVisualization_v2.Models;

namespace TraceabilityVisualization_v2.Data
{
    public class AsortymentContext : DbContext
    {
        public AsortymentContext(DbContextOptions<AsortymentContext> options) : base(options)
        {

        }
        public DbSet<Asortyment> Asortment { get; set; }
    }
}
