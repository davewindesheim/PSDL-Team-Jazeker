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
        void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;

        }

        private async void ButtonShowAlert_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Privacy Policy Statement for JVE-OGT", "Privacy Policy Statement for Google Android JVE-OGT app for tracking by JVE" + "\n" +
                "\nThe Google Android JVE - OGT app collects location data to enable route logging." +
                "\nThe app only starts with collecting data once you press the recording button in the app." +
                "\nIt requires a small amount of time to get your current position.Wait a second of five before you start moving." +
                "\nThe recording stops once you stops the tracking or set tracking on hold(pause)." +
                "\nOnce you use the button to stop recording of location data the GPX will be closed and finished." +
                "\nNow you are ready to submit(send) global data as date, start - and stop time and total achieved distance to us." +
                "\nTo get this global data the app uses your created GPX file on your phone to extract the required global data of your activity." +
                "\nSubmit(send) is only possible after you have specified some required data either(see Configuration settings)." + "\n" +
                "\nIf you decide to delete the recorded track on your phone be sure to check that you have received your activity summary details email." +
                "\nThe app can not recover your track once it is deleted." +
                "\nBefore delete you can export your track to file, but we can not import GPX files. " + "\n" +
                "\nRemarks" + "\n" +
                "\nDuring recording your app must be active in fore - or in background." +
                "\nAny active recording will be terminated when you quit the app(your recording is saved)." + "\n" +
                "\nConfiguration setting" + "\n" +
                "\nIn the app setting it is mandatory to define" +
                "\n-To which of our servers summary should be send" +
                "\n- To fill in the access code you got from us." + "\n" +
                "\nIn track details it is required to specify:" +
                "\n-The contest in which you are participating" +
                "\n- Your participant number." + "\n" +
                "\nAll data above that is required you can find in your participation paper." + "\n" +
                "\nSending activity data" + "\n" +
                "\nOur server uses your participant number for sending you an email." +
                "\n- If your number is not found or your email is not correct we can not send you an email." +
                "\n- If all your data is correct and you could access our server you will receive a prolongation email with the global data you just send to us." +
                "\nIf something is not correct you don't get an email from us." + "\n" +
                "\nAdditional validation afterwards" + "\n" +
                "\nAfter sending your activity data to us and receiving our progress email you might decide to deleted the GPX file" +
                "\nBut, in case you are one of the price getters we advise you to keep the track on your phone." +
                "\nTo make sure that there will be no issues afterwards we occasionly might request you to send the GPX to us for validation." + "\n" +
                "\nKinds regards" +
                "\nJahoma" + "\n" +
                "\nPolicy updated: v1 - 12 jan 2021 ", "Ok");
        }
        void Button2_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;

        }

        private async void ButtonShowAlert_Clicked2(object sender, System.EventArgs e)
        {
            await DisplayAlert("Prominent Disclosure Statement", "Prominent Disclosure Statement for GPS recording by JVE-OGT application" + "\n" +
                "\nThis app collects location data to enable registation of a track you are making." + "\nThe app only  collects data if you, the user, decides to start logging of a track."
                + "\nThe app does not collect any location data as long as tracking is not started." + "\nThe app stops collecting data if you ,the user, puts tracking on pause, stops the logging or close the app."
                + "\n" + "\nAs there is no actual location data at the moment one starts tracking available GPS satelites as well as your current location must be first discovered."
                + "\nThe discovery of the current location might take a second of ten."
                + "\nWe recommend to use the cross line target button to locate you current position before you start your logging"
                + "\n" + "\nIf the app is open and in tracking mode but your app is not visible (not on top) it keeps working and shall registrate your route."
                + "\nThe app does not collect any data once the tracking is on hold (pause) or logging is stopped." + "\nThe app is neither tracking if the app is closed."
                + "\n" + "\nCollected data by the app are not used to provide ads/support advertising/support ad." + "\nThe app does not know who you are at all."
                + "\n" + "\nKinds regards" + "\nJahoma" + "\n" + "\nProminent Disclosure Statement  updated : 24 jan 2021", "Ok");
        }

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