using AssignmentTrackerApp.Helpers;
using AssignmentTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
        }

        public void OnMuteButtonClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAppSettingsHelper>().OpenAppSettings();
        }
    }
}