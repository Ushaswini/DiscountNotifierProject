using System;
namespace DiscountNotifierAPI.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string OfferText { get; set; }
        public string OriginalPrice { get; set; }
        public string ImageUrl { get; set; }

        public string BeaconId { get; set; }
        public Beacon AssociatedBeacon { get; set; }
    }
}
