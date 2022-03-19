using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DiscountNotifierAPI.Models;
using Newtonsoft.Json;

namespace DiscountNotifierAPI.SeedData
{
    /// <summary>
    /// Model to deserialize SeedData.json Json data
    /// </summary>
    public class SeedDataModel
    {
        [JsonProperty("Discounts")]
        public List<Discount> Discounts { get; set; }

        [JsonProperty("Regions")]
        public List<Region> Regions { get; set; }

        [JsonProperty("Beacons")]
        public List<Beacon> Beacons { get; set; }

        [JsonProperty("Manufacturers")]
        public List<Manufacturer> Manufacturers { get; set; }

    }

    /// <summary>
    /// Class to read data from file
    /// </summary>
    public static class SeedData
    {
        private static string _fileName = @"SeedData/SeedData.json";

        public static SeedDataModel GetData()
        {
            string jsonString = File.ReadAllText(_fileName);
            return System.Text.Json.JsonSerializer.Deserialize<SeedDataModel>(jsonString);
        }
    }
}
