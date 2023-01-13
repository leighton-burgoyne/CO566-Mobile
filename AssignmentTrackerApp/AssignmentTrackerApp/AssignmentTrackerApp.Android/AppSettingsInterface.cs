using System;
using Android.Content;
using AssignmentTrackerApp.Droid;
using AssignmentTrackerApp.Helpers;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(AppSettingsInterface))]
namespace AssignmentTrackerApp.Droid
{
    public class AppSettingsInterface : IAppSettingsHelper
    {
        public void OpenAppSettings()
        {
            var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            string package_name = "com.companyname.assignmenttrackerapp";
            var uri = Android.Net.Uri.FromParts("package", package_name, null);
            intent.SetData(uri);
            Application.Context.StartActivity(intent);
        }

    }
}