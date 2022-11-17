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
        string _userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");
        public AssignmentsPage()
        {
            InitializeComponent();

            if (File.Exists(_userData))
            {
                editor.Text = File.ReadAllText(_userData);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_userData, editor.Text);
        }
        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_userData))
            {
                File.Delete(_userData);
            }
            editor.Text = string.Empty;
        }
    }
}