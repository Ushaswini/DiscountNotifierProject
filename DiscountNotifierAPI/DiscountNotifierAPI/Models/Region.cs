using System;
namespace DiscountNotifierAPI.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int BeaconId { get; set; }

        public Beacon Beacon { get; set; }
    }
}
