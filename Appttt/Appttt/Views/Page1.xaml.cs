using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appttt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            Participant.Text = "Participant number";
            Route.Text = "Route name";
            Date.Date = DateTime.Now.Date;
            StartTime.Time = DateTime.Now.TimeOfDay;
            StopTime.Time = DateTime.Now.TimeOfDay;
            Distance.Text = "Distance";
        }
    }
}