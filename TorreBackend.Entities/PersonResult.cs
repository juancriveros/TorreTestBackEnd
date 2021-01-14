using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class PersonResult
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public List<string> OpenTo { get; set; }
        public string Picture { get; set; }
        public string ProfessionalHeadline { get; set; }
        public bool Remoter { get; set; }
        public List<Skill> Skills { get; set; }
        public double SubjectId { get; set; }
        public string UserName { get; set; }
        public bool Verified { get; set; }
        public double Weigth { get; set; }
    }
}
