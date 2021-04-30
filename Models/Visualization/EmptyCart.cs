using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.Visualization
{
    [Keyless]
    public class EmptyCart
    {
        public string emptyCartsCounter { get; set; }
    }
}
