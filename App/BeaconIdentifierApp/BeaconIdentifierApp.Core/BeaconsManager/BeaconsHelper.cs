using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BeaconIdentifierApp.Core.Models;
using Newtonsoft.Json;

namespace BeaconIdentifierApp.Core.BeaconsManager
{
    public interface IDataHelper
    {
        public Task<List<string>> GetBeaconsIds();
        public Task<List<Discount>> GetDiscountsForABeaconRegion(string beaconId);
        public Task<List<Discount>> GetDiscounts();
    }


    public class DataHelper : IDataHelper
    {
        public async Task<List<string>> GetBeaconsIds() 
        {
            try
            {
                using(var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(ApiEndpoints.GetBeacons);
                    var beacons = JsonConvert.DeserializeObject<List<Beacon>>(data);
                    return beacons.Select(b => b.BeaconId).ToList();
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new List<string>();
            }
        }

        public async Task<List<Discount>> GetDiscountsForABeaconRegion(string beaconId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(string.Format(ApiEndpoints.GetDiscountsByBeaconRegion, beaconId));
                    return JsonConvert.DeserializeObject<List<Discount>>(data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new List<Discount>();
            }
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(ApiEndpoints.GetDiscounts);
                    return JsonConvert.DeserializeObject<List<Discount>>(data).OrderBy(d => d.AssociatedBeacon.AssociatedRegion.RegionId).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new List<Discount>();
            }
        }
    }
}
