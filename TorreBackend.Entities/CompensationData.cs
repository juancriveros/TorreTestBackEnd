using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class CompensationData
    {
        public string Code { get; set; }
        public string Currency { get; set; }
        public double? MinAmount { get; set; }
        public double? MaxAmount { get; set; }
        public string Periodicity { get; set; }

    }
}
