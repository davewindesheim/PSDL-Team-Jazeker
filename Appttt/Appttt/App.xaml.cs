using Appttt.Services;
using Appttt.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appttt
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
