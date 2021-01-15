using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorreBackend.API.Models
{
    public class SearchFilterModel
    {
        public bool Remote { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public double Compensation { get; set; }
        public string Periodicity { get; set; }
        public string Skill { get; set; }
        public string Type { get; set; }
        public int Offset { get; set; }
    }
}
