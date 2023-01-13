using AssignmentTrackerApp.Data;
using AssignmentTrackerApp.Models;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignmentsPage : ContentPage
    {
        public AssignmentsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            AssignmentDbContext database = await AssignmentDbContext.Instance;
            listView.ItemsSource = await database.GetAssignmentsAsync();
        }
        async void OnNewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssignmentDetailsPage
            {
                BindingContext = new Assignment()
            });
        }

        async void OnAssignmentSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if(e.ItemData != null)
            {
                await Navigation.PushAsync(new AssignmentDetailsPage
                {
                    BindingContext = e.ItemData as Assignment
                });
            }
        }

    }
}