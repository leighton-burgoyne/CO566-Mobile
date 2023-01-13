using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AssignmentTrackerApp.Views;
using AssignmentTrackerApp.Models;
using AssignmentTrackerApp.Data;
using SQLite;

namespace AssignmentTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public string Greeting { get; set; }

        public HomePage()
        {
            InitializeComponent();

            CalendarInlineEvent events = new CalendarInlineEvent();
            events.StartTime = DateTime.Today;
            events.EndTime = DateTime.Today;
            events.Subject = "Database Design TCA1";
            events.Color = Color.Orange;

            CalendarEventCollection calendarEventCollection = new CalendarEventCollection();
            CalendarEventCollection collection = calendarEventCollection;
            collection.Add(events);

            calendar.DataSource = collection;

            calendar.InlineToggled += Calendar_InlineToggled;
            calendar.OnInlineLoaded += Calendar_OnInlineLoaded;
            calendar.InlineItemTapped += Calendar_InlineItemTapped;

            DateTime timeSegment = DateTime.Now;
/*
            if (timeSegment.Hour >= 5 && timeSegment.Hour < 12)
            {
                Greeting = "Good Morning! &#x2600;";
            }

            else if (timeSegment.Hour >= 12 && timeSegment.Hour < 16)
            {
                Greeting = "Good Afternoon! &#xE11D;";
            }
            else
            {
                Console.WriteLine("Good Evening! &#x1F303");
            }*/

        }

        void Calendar_InlineToggled(object sender, InlineToggledEventArgs e)
        {
            // No Method Available
        }

        void Calendar_OnInlineLoaded(object sender, InlineEventArgs e)
        {
            Grid grid = new Grid();
            grid.BackgroundColor = Color.WhiteSmoke;
            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Star;
            RowDefinition rowDefinition1 = new RowDefinition();
            rowDefinition.Height = GridLength.Star;

            grid.RowDefinitions.Add(rowDefinition);
            grid.RowDefinitions.Add(rowDefinition1);

            Label label = new Label();
            label.HorizontalOptions = LayoutOptions.Center;
            label.VerticalOptions = LayoutOptions.Center;
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.VerticalTextAlignment = TextAlignment.Center;

            label.TextColor = Color.Gray;
            label.Text = "No Assignments Due";
            label.FontSize = 15;

            grid.Children.Add(label, 0, 0);

            if (e.Appointments.Count == 0)
            {
                e.View = grid;
            }
        }
        private void Calendar_InlineItemTapped(object sender, InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            DisplayAlert(appointment.Subject, appointment.StartTime.ToString(), "Dismiss");
        }
    }
}