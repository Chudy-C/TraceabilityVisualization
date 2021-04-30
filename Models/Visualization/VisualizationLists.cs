using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.Visualization
{
    [Keyless]
    public class VisualizationLists
    {
        public List<CountCartsWithPW> listWithPW { get; set; }
        public List<CountCartsWithoutPW> listWithoutPW { get; set; }

        public string emptyCartCounter {get; set;}

        public List<EmptyCart> listEmptyCartsCount { get; set; }
    }
}
