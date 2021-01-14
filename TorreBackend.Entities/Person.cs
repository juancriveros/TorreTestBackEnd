using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Person
    {
        [JsonProperty("person")]
        public PersonInfo Info { get; set; }
        public Stats Stats { get; set; }
        public List<Strength> Strengths { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Opportunity> Opportunities { get; set; }
        public List<Language> Languages { get; set; }
        public List<OpportunityResult> IdealJob { get; set; }
    }
}
