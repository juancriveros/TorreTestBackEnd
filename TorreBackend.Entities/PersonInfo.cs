using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class PersonInfo
    {
        public string ProfessionalHeadline { get; set; }
        public double Completion { get; set; }
        public bool ShowPhone { get; set; }
        public DateTime Created { get; set; }
        public bool Verified { get; set; }
        //
        public int Weight { get; set; }
        public string Locale { get; set; }
        public double SubjectId { get; set; }
        public bool HasEmail { get; set; }
        public string Name { get; set; }
        //
        public Location Location { get; set; }
        public string Theme { get; set; }
        public string Id { get; set; }
        public bool Claiant { get; set; }
        public string WeightGraph { get; set; }
        public string PublicId { get; set; }
    }
}
