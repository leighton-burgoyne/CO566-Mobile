using AssignmentTrackerApp.Data;
using AssignmentTrackerApp.Models;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentTrackerApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace AssignmentTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignmentDetailsPage : ContentPage
    {
        public CalendarEventCollection AssignmentEvents { get; set; }
        public AssignmentDetailsPage()
        {
            InitializeComponent();
        }
        async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            var assignment = (Assignment)BindingContext;
            AssignmentDbContext database = await AssignmentDbContext.Instance;
            await database.SaveAssignmentAsync(assignment);
            AddAssignmentsCalendar();
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object semder, EventArgs e)
        {
            var assignment = (Assignment)BindingContext;
            AssignmentDbContext database = await AssignmentDbContext.Instance;
            await database.DeleteAssignmentAsync(assignment);

            await Navigation.PopAsync();
        }
        private void AddAssignmentsCalendar()
        {
            AssignmentEvents = new CalendarEventCollection();
            var EventName = TitleField.Text;
            var From = DateTime.Now;
            var To = DueDateField.Date;
            var AllDay = false;

            AssignmentEvents.Add(new CalendarInlineEvent()
                {
                    Subject = EventName,
                    StartTime = From,
                    EndTime = To,
                    Color = Color.Blue,
                    IsAllDay = AllDay,
                });
            }
        }
}