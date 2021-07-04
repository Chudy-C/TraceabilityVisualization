using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Models.Traceability
{
    public class TraceabilityLists
    {
        public List<Komora> Komora { get; set; }
        public List<Wozek> Wozek { get; set; }
        public List<Suszarnia> Suszarnia { get; set; }

    }
}
