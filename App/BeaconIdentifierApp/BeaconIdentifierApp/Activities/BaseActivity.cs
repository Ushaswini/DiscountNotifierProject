
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
        protected ProgressBar _progressDialog;

        protected override void OnResume()
        {
            base.OnResume();
            _progressDialog = FindViewById<ProgressBar>(Resource.Id.progressBar);
        }

        protected virtual void ShowProgress()
        {
            if ((_progressDialog == null) || (_progressDialog != null && _progressDialog.Visibility == ViewStates.Visible))
                return;

            RunOnUiThread(() =>
            {
                _progressDialog.Visibility = ViewStates.Visible;
            });
        }

        protected virtual void DismissProgress()
        {
            if ((_progressDialog == null) || (_progressDialog != null && _progressDialog.Visibility == ViewStates.Gone))
                return;

            RunOnUiThread(() =>
            {
                _progressDialog.Visibility = ViewStates.Gone;
            });
        }
    }
}
