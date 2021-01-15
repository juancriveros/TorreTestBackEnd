using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class OpportunityResult
    {
        public string Id { get; set; }
        public string Objective { get; set; }
        public string Type { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<string> Locations { get; set; }
        public bool Remote { get; set; }
        public bool External { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
        public Compensation Compensation { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Member> Members { get; set; }
        public int Offset { get; set; }
    }
}
