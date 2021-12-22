using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appttt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Landing : ContentPage
    {
        public Landing()
        {
            InitializeComponent();
            AnimateCarousel();
        }

        Timer timer;

        private void AnimateCarousel()
        {
            timer = new Timer(5000) { AutoReset = true, Enabled = true };

            timer.Elapsed += (s, e) =>
            {
                if (LandingVideo.CurrentState != MediaElementState.Playing)
                    LandingVideo.Play();

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (cvOnboarding.Position == 4)
                    {
                        cvOnboarding.Position += 0;
                        return;
                    }

                    cvOnboarding.Position += 1;
                });
            };

        }

        private async void GetStarted_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}