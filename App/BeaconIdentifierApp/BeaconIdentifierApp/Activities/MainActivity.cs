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
using System.Threading.Tasks;
using System.Linq;
using System;
using AndroidX.RecyclerView.Widget;
using Android.Views;

namespace BeaconIdentifierApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity, BeaconManager.IServiceReadyCallback
    {
        private BeaconManager _beaconManager;
        private BeaconsHelper _beaconsHelper;
        private BeaconRegion[] _regions;
        private List<string> _beaconIds;
        private DiscountsAdapter _adapter;
        private List<Discount> _discounts;
        private RecyclerView _discountsRv;
        private EstimoteSdk.Recognition.Packets.Beacon _currentBeacon;
        DateTime _lastActiveTime;
        private View _emptyView;

        const string BeaconId = "com.refractored";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _discountsRv = FindViewById<RecyclerView>(Resource.Id.discountsListView);
            _emptyView = FindViewById<LinearLayout>(Resource.Id.emptyView);

            _discounts = new List<Discount>();
            _adapter = new DiscountsAdapter(_discounts);
            _adapter.OnListChanged += OnListChanged;    
            _discountsRv.SetLayoutManager(new LinearLayoutManager(this));
            _discountsRv.SetAdapter(_adapter);

            _beaconsHelper = new BeaconsHelper();

            _beaconsHelper.GetBeaconsIds().ContinueWith((result) =>
            {
                try
                {
                    _beaconIds = result.Result;
                    _regions = new BeaconRegion[_beaconIds.Count];

                    RunOnUiThread(() => {
                        _beaconManager = new BeaconManager(this);
                        _beaconManager.SetForegroundScanPeriod(150, 12000);
                        _beaconManager.BeaconRanging += BeaconRanging;
                        _beaconManager.BeaconExitedRegion += BeaconExitedRegion;    
                        _beaconManager.Connect(this);
                    });
                   
                }
                catch (System.Exception ex)
                {
                    Log.Debug(nameof(MainActivity), ex.Message);
                }
               

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            PullData();

        }

        private void OnListChanged(object sender, bool show)
        {
            DismissProgress();
            ToggleEmptyView(show);
        }

        private async void BeaconExitedRegion(object sender, BeaconManager.BeaconExitedRegionEventArgs e)
        {
            _currentBeacon = null;
            await PullData();
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
                        _lastActiveTime = DateTime.Now;
                        var accuracy = EstimoteSdk.Observation.Region.RegionUtils.ComputeAccuracy(beacon);
                        if (accuracy < .06)
                            continue;
                        else
                        {
                            //Get region data
                            Log.Debug(nameof(MainActivity), beacon.ProximityUUID.ToString());

                            if(_currentBeacon?.ProximityUUID != beacon.ProximityUUID)
                            {
                                //Pull data only if it's a new beacon region
                                _currentBeacon = beacon;
                                await PullData(beacon.ProximityUUID.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                if ((DateTime.Now - _lastActiveTime).TotalMinutes > 2)
                {
                    _currentBeacon = null;
                    await PullData();
                    _lastActiveTime = DateTime.Now;
                }
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            _beaconManager?.Disconnect();
        }

        public void OnServiceReady()
        {
            for(int i = 0; i< _beaconIds.Count;i++ )
            {
                _regions[i] = new BeaconRegion(BeaconId, _beaconIds[i]);
                _beaconManager?.StartRanging(_regions[i]);
            }
        }

        private async Task PullData(string filter = default)
        {
            ShowProgress();

            List<Discount> discounts;
            if(!string.IsNullOrEmpty(filter))
            {
                discounts = await _beaconsHelper.GetDiscountsForABeaconRegion(filter);
            }
            else
            {
                discounts = await _beaconsHelper.GetDiscounts();
            }

            if(discounts.Any())
            {
                _discounts = discounts;
                RunOnUiThread(() => {
                    _adapter.UpdateData(_discounts);
                });
            }

            DismissProgress();
        }

        private void ToggleEmptyView(bool show)
        {
            if(_emptyView != null)
            {
                _emptyView.Visibility = show ? ViewStates.Visible : ViewStates.Gone;
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
