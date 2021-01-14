using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Interest
    {
        public string Id { get; set; }
        public double Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}
