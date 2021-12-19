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
    public partial class ShopRoute1 : ContentPage
    {
        public ShopRoute1()
        {
            InitializeComponent();
        }
        private void Button_Leaderboards(object sender, EventArgs e)
        {
            var Url = "https://jve.jahoma.nl/nl/contest/16/";
            Browser.Source = Url;
        }
    }
}