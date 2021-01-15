using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorreBackend.API.Models
{
    public class CompensationDataModel
    {
        public string Code { get; set; }
        public string Currency { get; set; }
        public double? MinAmount { get; set; }
        public double? MaxAmount { get; set; }
        public string Periodicity { get; set; }

    }
}
