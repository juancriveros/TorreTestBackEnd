using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class AggregatorOpportunity
    {
        public List<AgregatorValue> Remote { get; set; }
        public List<AgregatorValue> Organization { get; set; }
        public List<AgregatorValue> Skill { get; set; }
        public List<AgregatorValue> CompensationRange { get; set; }
        public List<AgregatorValue> Type{ get; set; }
        public List<AgregatorValue> Status{ get; set; }
    }
}
