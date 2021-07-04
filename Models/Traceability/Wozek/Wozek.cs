using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.Traceability
{
    public class Wozek
    {
        [Key]
        public int ID_Wozka { get; set; }
        public string Nr_wozka { get; set; }
        public string Waga_kg { get; set; }
        public string Lokalizacja { get; set; }
    }
}

