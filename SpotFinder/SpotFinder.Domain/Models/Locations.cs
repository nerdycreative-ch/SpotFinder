using System;
using System.Collections.Generic;

namespace SpotFinder.Domain.Models
{
    public partial class Locations
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
