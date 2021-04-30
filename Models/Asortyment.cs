using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraceabilityVisualization_v2.Models.AsortymentVisualization;

namespace TraceabilityVisualization_v2.Models
{
    [Keyless]
    public class Asortyment
    {
        public List<AllMaterials> allMaterialAsortmentList { get; set; }
        public List<SuszarniaAsortyment> suszarniaAsortymentList { get; set; }
        public List<KomoraAsortyment> komoraAsortymentList { get; set; }
        public List<PrzewijalniaAsortyment> przewijalniaAsortymentList { get; set; }
    }
}
