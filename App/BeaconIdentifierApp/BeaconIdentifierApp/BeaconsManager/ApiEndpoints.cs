using System;
namespace BeaconIdentifierApp.BeaconsManager
{
    public static class ApiEndpoints
    {
        public static string HostEndpoint => "https://discountnotifierapi.azurewebsites.net";
        public static string GetRegions => $"{HostEndpoint}/api/Regions";
        public static string GetBeacons => $"{HostEndpoint}/api/Beacons";
        public static string GetDiscounts => $"{HostEndpoint}/api/Discounts";
        public static string GetDiscountsByBeaconRegion => $"{HostEndpoint}/api/Discounts/beaconId={0}";



    }
}
