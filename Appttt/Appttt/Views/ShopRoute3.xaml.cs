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
    public partial class ShopRoute3 : ContentPage
    {
        public ShopRoute3()
        {
            InitializeComponent();
        }
        private void Button_Leaderboards(object sender, EventArgs e)
        {
            var Url = "https://jve.jahoma.nl/nl/contest/60/";
            Browser.Source = Url;
        }
    }
}