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
        }
        // When camera button is clicked the code below awaits the camera and checks for permission,
        // if not granted yet it asks for permission.
        private async void ShowCamera_Clicked(object sender, EventArgs e)
        {
            Plugin.Media.Abstractions.MediaFile photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

            PermissionStatus permissions = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (permissions != PermissionStatus.Granted)
            {
                permissions = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (permissions != PermissionStatus.Granted)
            {
                return;
            }
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
        // Button to open the current QR scanner, it awaits for user to show an QR when succesfully scan, it returns "result"
        // the results currently shows in an DisplayAlert which should be updated later on.
        private async void Button_ClickedScan(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Scanned", "" + result.Text, "Ok");

                });
            };
        }
    }
}