using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization.Models
{
    public class KomoraWozek
    {
        [Key]
        public int ID_Trace { get; set; }
        public string Nr_wozka { get; set; }
        public string Nm { get; set; }
        public string Material { get; set; }
        public string Typ_cewki { get; set; }
        public string Kolor_cewki { get; set; }
        public DateTime? TS_KOM1 { get; set; }


    }
}
