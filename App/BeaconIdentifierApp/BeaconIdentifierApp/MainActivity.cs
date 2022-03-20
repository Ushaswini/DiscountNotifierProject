using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using EstimoteSdk.Service;
using EstimoteSdk.Observation.Region.Beacon;
using EstimoteSdk.Observation.Utils;
using Android.Util;
using BeaconIdentifierApp.BeaconsManager;
using System.Collections.Generic;
using BeaconIdentifierApp.Adapter;
using BeaconIdentifierApp.Models;
using Android.Widget;

namespace BeaconIdentifierApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BeaconManager.IServiceReadyCallback
    {
        private BeaconManager _beaconManager;
        private BeaconsHelper _beaconsHelper;
        private BeaconRegion[] _regions;
        private List<string> _beaconIds;
        private DiscountsAdapter _adapter;
        private List<Discount> _discounts;
        private ListView lv;

        const string BeaconId = "com.refractored";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            lv = FindViewById<ListView>(Resource.Id.listView);
            _discounts = new List<Discount>();
            _adapter = new DiscountsAdapter(this, _discounts);
            lv.Adapter = _adapter;

            _beaconsHelper = new BeaconsHelper();
            _beaconIds = await _beaconsHelper.GetBeaconsIds();
            _regions = new BeaconRegion[_beaconIds.Count];

            _beaconManager = new BeaconManager(this);

            _beaconManager.BeaconRanging += BeaconRanging;
            _beaconManager.SetForegroundScanPeriod(150, 2000);
        }

        private async void BeaconRanging(object sender, BeaconManager.BeaconRangingEventArgs e)
        {
            if(e.Beacons.Count > 0)
            {
                foreach (var beacon in e.Beacons)
                {
                    var proximity = EstimoteSdk.Observation.Region.RegionUtils.ComputeProximity(beacon);

                    if (proximity != Proximity.Unknown)
                    {
                        var accuracy = EstimoteSdk.Observation.Region.RegionUtils.ComputeAccuracy(beacon);
                        if (accuracy < .06)
                            continue;
                        else
                        {
                            //Get region data
                            Log.Debug("demo", beacon.ProximityUUID.ToString());
                            var discounts = await _beaconsHelper.GetDiscountsForABeaconRegion(beacon.ProximityUUID.ToString());
                            RunOnUiThread(() => {
                                _adapter.UpdateData(discounts);
                            });
                        }
                            
                    }
                }
            }
            else
            {
                var discounts = await _beaconsHelper.GetDiscounts();
                RunOnUiThread(() => {
                    _adapter.UpdateData(discounts);
                });
            }
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            _beaconManager.Connect(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _beaconManager.Disconnect();
        }

        public void OnServiceReady()
        {
            for(int i = 0; i< _beaconIds.Count;i++ )
            {
                _regions[i] = new BeaconRegion(BeaconId, _beaconIds[i]);
                _beaconManager.StartRanging(_regions[i]);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}
