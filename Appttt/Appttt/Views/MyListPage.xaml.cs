using System;
using System.Collections.Generic;
using MyListNavigation.Models;
using MyListNavigation.ViewModel;
using Xamarin.Forms;

namespace Appttt.Views
{
    public partial class MyListPage : ContentPage
    {
        public MyListPage()
        {
            InitializeComponent();
            // Binds the myListPage Model to myListPage
            BindingContext = new MyListPageViewModel();
        }


        // When item tapped myselectedItem selects the right route
        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            if (flowlistview.SelectedItem == null)
                return;

            var myselecteditem = e.Item as MyListModel;

            switch (myselecteditem.id)
            {

                case 1:
                    await Navigation.PushAsync(new ShopRoute1());
                    break;
                case 2:
                    await Navigation.PushAsync(new ShopRoute2());
                    break;
                case 3:
                    await Navigation.PushAsync(new ShopRoute3());
                    break;


            }
                ((ListView)sender).SelectedItem = null;



        }
    }
}