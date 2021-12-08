using System;
using System.Collections.ObjectModel;
using MyListNavigation.Models;

namespace MyListNavigation.ViewModel
{
    public class MyListPageViewModel
    {

        public ObservableCollection<MyListModel> MyListCollector { get; set; }


        public MyListPageViewModel()
        {


            MyListCollector = new ObservableCollection<MyListModel>()
            {
                new MyListModel(){id = 1 , RouteName = "The 100 of Lier 2021/2022 " , RouteDetail = "Although Flanders has many beautiful cities" },
                new MyListModel(){ id = 2 , RouteName = "The 1000 of Lier 2021/2022" , RouteDetail = "Lier: “Pearl of Flanders”" },
                new MyListModel(){ id = 3 , RouteName = "JVE-60-Windesheim" , RouteDetail = "Young pearls' but especially for the ICT students of Windesheim Almere" },
            };

        }
    }
}