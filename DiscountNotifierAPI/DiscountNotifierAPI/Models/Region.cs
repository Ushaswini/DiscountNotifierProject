using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountNotifierAPI.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
    }
}
