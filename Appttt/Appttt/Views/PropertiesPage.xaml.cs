using Appttt.ViewModels;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Appttt.Views
{
    public partial class PropertiesPage : ContentPage
    {
        bool isGettingLocation;

        public PropertiesPage()
        {
            InitializeComponent();
            switch (ThemeSettings.Theme)
            {
                case 0:
                    RadioButtonSystem.IsChecked = true;
                    break;
                case 1:
                    RadioButtonLight.IsChecked = true;
                    break;
                case 2:
                    RadioButtonDark.IsChecked = true;
                    break;
            }
        }

        bool loaded;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loaded = true;
        }

        void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!loaded)
                return;

            if (!e.Value)
                return;

            var val = (sender as RadioButton)?.Value as string;
            if (string.IsNullOrWhiteSpace(val))
                return;

            switch (val)
            {
                case "System":
                    ThemeSettings.Theme = 0;
                    break;
                case "Light":
                    ThemeSettings.Theme = 1;
                    break;
                case "Dark":
                    ThemeSettings.Theme = 2;
                    break;
            }

            TheTheme.SetTheme();
        }
        // Button to get current Location, it currently returns the Latitude and Longitude in text, the task.delay
        // should be in the documentation of Geolocation.
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = true;

            while (isGettingLocation)
            {
                var result = await Geolocation.GetLocationAsync(new
                  GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

                resultLocation.Text = $"lat: {result.Latitude}, lng: {result.Longitude} {Environment.NewLine}";

                await Task.Delay(1000);
            }

        }
        // Button to stop the current location tracking.
        void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;

        }
        void Button2_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;

        }
    }
}