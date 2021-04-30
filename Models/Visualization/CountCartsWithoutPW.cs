using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.Visualization
{
    [Keyless]
    public class CountCartsWithoutPW
    {
        public string asortyment { get; set; }
        public string przedzalnia { get; set; }
        public string suszarnia { get; set; }
        public string komora { get; set; }
        public string suma { get; set; }
    }
}
