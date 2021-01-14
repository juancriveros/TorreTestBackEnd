using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class PersonSearch
    {
        public AgregatorPerson Aggregators { get; set; }
        public List<PersonResult> Results { get; set; }
        public int Size { get; set; }
        public double Total { get; set; }
    }
}
