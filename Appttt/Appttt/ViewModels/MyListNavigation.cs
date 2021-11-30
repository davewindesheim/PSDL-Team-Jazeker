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
                new MyListModel(){ id = 2 , RouteName = "De 1000 van Lier 2021/2022" , RouteDetail = "Lier: “Parel van Vlaanderen”" },
                new MyListModel(){ id = 3 , RouteName = "JVE-60-Windesheim" , RouteDetail = "Jonge parels’ maar dan special voor de ICT studenten van Windesheim Almere" },
            };

        }
    }
}