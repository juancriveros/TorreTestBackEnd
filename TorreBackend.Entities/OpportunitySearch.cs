using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class OpportunitySearch
    {
        public AggregatorOpportunity Aggregators { get; set; }
        public int Offset { get; set; }
        public List<OpportunityResult> Results { get; set; }
        public int Size { get; set; }
        public double Total { get; set; }
    }
}
