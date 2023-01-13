using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void OnInfoButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Created by Leighton Burgoyne\nBuild 01 (02/01/2023)", "CLOSE");
        }

        public void OnSaveSettingsButtonClicked(object sender, EventArgs e)
        {
            // To Complete
        }
    }
}