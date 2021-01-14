using System;
using System.Collections.Generic;
using System.Text;

namespace TorreBackend.Entities
{
    public class Location
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Latitud { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; }
        public double TimeZoneOffset { get; set; }

    }
}
