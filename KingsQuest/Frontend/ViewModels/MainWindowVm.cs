using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;
using Engine;

namespace Frontend.ViewModels
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        private string _currentStatus;

        public string CurrentStatus
        {
            get => _currentStatus;
            private set { _currentStatus = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Room> AdjacentRooms { get; private set; }

        public MainWindowVm(GameEngine gameEngine)
        {
            AdjacentRooms = new ObservableCollection<Room>();
            UpdateFromGameEngine(gameEngine);
        }

        public void UpdateFromGameEngine(GameEngine gameEngine)
        {
            CurrentStatus = gameEngine.StateDescription;
            AdjacentRooms.Clear();
            foreach (var room in gameEngine.AdjacentRooms)
            {
                AdjacentRooms.Add(room);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}