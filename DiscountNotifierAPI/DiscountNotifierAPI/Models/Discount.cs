using System;
namespace DiscountNotifierAPI.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string DiscountPercentage { get; set; }
        public string OfferText { get; set; }
        public string OriginalPrice { get; set; }
        public string ImageUrl { get; set; }

        public int RegionId { get; set; }
        public Region AssociatedRegion { get; set; }
    }
}
