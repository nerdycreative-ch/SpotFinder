using System;
using System.Collections.Generic;

namespace SpotFinder.Domain.Models
{
    public partial class Spots
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SpotTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
