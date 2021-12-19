using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appttt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopRoute2 : ContentPage
    {
        public ShopRoute2()
        {
            InitializeComponent();
            var Url = "https://jve.jahoma.nl/nl/contest/15/";
            Browser.Source = Url;
        }
    }
}