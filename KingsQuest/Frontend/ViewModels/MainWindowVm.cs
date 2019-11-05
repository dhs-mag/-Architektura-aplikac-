using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;
using Data.Things.Contract;
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
        
        public Room SelectedRoom { get; set; }

        public ObservableCollection<Room> AdjacentRooms { get; }
        
        public ObservableCollection<Thing> RoomItems { get; }
        
        public ObservableCollection<IPickable> Inventory { get; }

        public MainWindowVm(GameEngine gameEngine)
        {
            AdjacentRooms = new ObservableCollection<Room>();
            RoomItems = new ObservableCollection<Thing>();
            Inventory = new ObservableCollection<IPickable>();
            UpdateFromGameEngine(gameEngine);
        }

        public void UpdateFromGameEngine(GameEngine gameEngine)
        {
            CurrentStatus = gameEngine.GetStateDescription(false);
            AdjacentRooms.Clear();
            foreach (var room in gameEngine.AdjacentRooms)
            {
                AdjacentRooms.Add(room);
            }
            RoomItems.Clear();
            foreach (var thing in gameEngine.CurrentRoom.ThingsInside)
            {
                RoomItems.Add(thing);
            }
            Inventory.Clear();
            foreach (var pickable in gameEngine.CurrentPlayer.Inventory.Contents)
            {
                Inventory.Add(pickable);
            }
        }

        // interface implementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}