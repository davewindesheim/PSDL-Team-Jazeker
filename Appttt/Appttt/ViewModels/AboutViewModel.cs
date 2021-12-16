using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Appttt.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Virtual Tourist";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://newtownfestival.nl"));
            ShopRoute1Web = new Command(async () => await Browser.OpenAsync("https://www.virtualtourist.nl/product/de-100-van-lier-2021-2022/"));
            ShopRoute2Web = new Command(async () => await Browser.OpenAsync("https://www.virtualtourist.nl/product/de-1000-van-lier-2021-2022/"));
            ShopRoute3Web = new Command(async () => await Browser.OpenAsync("https://www.virtualtourist.nl/product/jve-60/"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand ShopRoute1Web { get; }
        public ICommand ShopRoute2Web { get; }
        public ICommand ShopRoute3Web { get; }
    }
}