using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Member
    {
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ProfessionalHeadline { get; set; }
        public string Picture { get; set; }
        public bool IsMember { get; set; }
        public bool Manager { get; set; }
        public bool Poster { get; set; }
        public double Weight { get; set; }
    }
}
