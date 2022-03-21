
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BeaconIdentifierApp.Activities
{
    public class BaseActivity : AppCompatActivity
    {   
        protected virtual void ShowProgress()
        {
            var _progressDialog = FindViewById<ProgressBar>(Resource.Id.progressBar);

            if ((_progressDialog == null) || (_progressDialog != null && _progressDialog.Visibility == ViewStates.Visible))
                return;

            RunOnUiThread(() =>
            {
                _progressDialog.Visibility = ViewStates.Visible;
            });
        }

        protected virtual void DismissProgress()
        {
            var _progressDialog = FindViewById<ProgressBar>(Resource.Id.progressBar);

            if ((_progressDialog == null) || (_progressDialog != null && _progressDialog.Visibility == ViewStates.Gone))
                return;

            RunOnUiThread(() =>
            {
                _progressDialog.Visibility = ViewStates.Gone;
            });
        }
    }
}
