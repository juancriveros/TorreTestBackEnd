using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class AgregatorPerson
    {
        public List<AgregatorValue> Opento { get; set; }
        public List<AgregatorValue> Remoter{ get; set; }
        public List<AgregatorValue> Skill { get; set; }
        public List<AgregatorValue> CompensationRange { get; set; }

    }
}
