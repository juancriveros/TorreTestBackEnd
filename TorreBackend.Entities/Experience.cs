using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Experience
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public List<Organization> Organizations { get; set; }

        //
        public string FromMonth { get; set; }
        public int FromYear { get; set; }
        public string ToMonth { get; set; }
        public int ToYear { get; set; }
        public bool Highlighted { get; set; }
        public int Weight { get; set; }
        public int Verifications { get; set; }
        public int Recommendations { get; set; }

    }
}
