using System;
namespace MyListNavigation.Models
{
    // Currently the model for the MyListModel, the current Shop.
    public class MyListModel
    {
        public int id { get; set; }
        public string RouteName { get; set; }
        public string RouteDetail { get; set; }
    }
}