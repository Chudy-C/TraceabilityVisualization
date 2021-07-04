using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Models.Traceability
{
    public class Komora
    {
        [Key]
        public int ID_Trace { get; set; }
        [Display(Name ="Numer wózka")]
        public string Nr_wozka { get; set; }
        public string Nm { get; set; }
        [Display(Name = "Materiał")]
        public string Material { get; set; }
        [Display(Name = "Typ cewki")]
        public string Typ_cewki { get; set; }
        [Display(Name = "Kolor cewki")]
        public string Kolor_cewki { get; set; }
        [Display(Name = "Data wstawienia")]
        public DateTime? TS_KOM1 { get; set; }

    }
}
