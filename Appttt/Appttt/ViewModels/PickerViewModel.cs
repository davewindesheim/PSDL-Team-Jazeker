using Appttt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Appttt.ViewModels
{
    public class PickerViewModel: INotifyPropertyChanged
    {
        public List<Leaderboards> Leaderboard { get; set; }
        public PickerViewModel()
        {
            Leaderboard = new List<Leaderboards>();
            Leaderboard.Add(new Leaderboards() { ItemID = 1, ItemName = "The 1000 of Lier 2021/2022", Url = "https://jve.jahoma.nl/nl/contest/15/" });
            Leaderboard.Add(new Leaderboards() { ItemID = 2, ItemName = "The 100 of Lier 2021/2022", Url = "https://jve.jahoma.nl/nl/contest/16/" });
            Leaderboard.Add(new Leaderboards() { ItemID = 3, ItemName = "Virtual Tourist Windesheim", Url = "https://jve.jahoma.nl/nl/contest/60/" });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Leaderboards _Leaderboards;
        public Leaderboards SelectedLeaderboards
        {
            get { return _Leaderboards; }
            set { _Leaderboards = value;
                OnPropertyChanged();
            }
        }
    }
}
