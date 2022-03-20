using System;
using System.ComponentModel.DataAnnotations;

namespace DiscountNotifierAPI.Models
{
    public class Beacon
    {
        public string BeaconId { get; set; }
        public int ManufacturerId { get; set; }

        public int RegionId { get; set; }
        public Region AssociatedRegion { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
