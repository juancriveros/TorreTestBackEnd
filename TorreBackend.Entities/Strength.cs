using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Strength
    {
        public string Id { get; set; }
        public double Code { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Recommendations { get; set; }
        public DateTime Created { get; set; }

        public string Experience { get; set; }

    }
}
