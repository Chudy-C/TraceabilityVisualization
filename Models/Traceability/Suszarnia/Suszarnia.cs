using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.Traceability
{
    public class Suszarnia
    {
        [Key]
        public int ID_Trace { get; set; }
        [Display(Name = "Numer wózka")]
        public string Nr_wozka { get; set; }
        public string Nm { get; set; }
        [Display(Name = "Materiał")]
        public string Material { get; set; }
        [Display(Name = "Typ cewki")]
        public string Typ_cewki { get; set; }
        [Display(Name = "Kolor cewki")]
        public string Kolor_cewki { get; set; }
        [Display(Name ="Suszarnia")]
        public string Suszenie1 { get; set; }
        [Display(Name = "Data wstawienia")]
        public DateTime? TS_SUSZ1 { get; set; }
    }
}
