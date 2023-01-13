using AssignmentTrackerApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentTrackerApp
{
    public partial class App : Application
    {

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTI5MTQ5QDMyMzAyZTM0MmUzMFg3QWVOZzBTMll2UDhuSnN6VU9BZnZnNVdqQTBRb0pmMFBzU25Rd2ttSHM9");
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
