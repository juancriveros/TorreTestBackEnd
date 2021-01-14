using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class OpportunityProfile
    {
        public string Objective { get; set; }
        public List<OpportunityDetails> Details { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
        public List<Strength> Strengths { get; set; }
        public List<PersonResult> IdealPerson { get; set; }
    }
}
