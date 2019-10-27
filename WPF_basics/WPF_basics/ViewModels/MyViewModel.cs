using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_basics.Models;

namespace WPF_basics.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> Users { get; set; }

        public int Travelers => Users.Count;

        private int _TicketPrice;

        public int TicketPrice
        {
            get => _TicketPrice;
            set
            {
                _TicketPrice = value;
                NotifyPropertyChanged(nameof(TicketPrice));
                NotifyPropertyChanged(nameof(TravelCost));
                NotifyPropertyChanged(nameof(BudgetExceeded));
            }
        }

        public int TravelCost => TicketPrice * Users.Count;

        private int _Budget;

        public int Budget
        {
            get => _Budget;
            set
            {
                _Budget = value;
                NotifyPropertyChanged(nameof(Budget));
                NotifyPropertyChanged(nameof(BudgetExceeded));
            }
        }

        public bool BudgetExceeded => TravelCost > Budget;


        public MyViewModel()
        {
            Users = new ObservableCollection<User>();

            // For simplicity we fill our collection here, but this should be done in model.
            Users.Add(new User() {Name = "Franta Lala"});
            Users.Add(new User() {Name = "John Doe"});
            Users.Add(new User() {Name = "Milos Big"});
            Users.Add(new User() {Name = "User 4"});
            Users.Add(new User() {Name = "User 5"});
            Users.Add(new User() {Name = "User 6"});
            Users.Add(new User() {Name = "User 7"});
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}