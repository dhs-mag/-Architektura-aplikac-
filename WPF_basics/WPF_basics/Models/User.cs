using System.ComponentModel;
using System.Linq;

namespace WPF_basics.Models
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                NotifyPropertyChanged(null);
            }
        }

        public int Age { get; set; }


        public string FirstName => Name.Split(' ').FirstOrDefault();
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
