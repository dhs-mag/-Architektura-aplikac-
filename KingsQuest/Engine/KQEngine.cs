using Data;
using System.Collections.Generic;

namespace Engine
{
    public class KQEngine
    {
        private readonly IUserInterface Ui;
        
        public Room CurrentRoom { get; private set; }

        private readonly List<Item> _inventory;
        public IEnumerable<Item> Inventory => _inventory.ToArray();

        public KQEngine(IUserInterface ui)
        {
            Ui = ui;
            _inventory = new List<Item>();
        }

        public void GameInit()
        {
            Room forest = new Room()
            {
                Name = "Forest",
                Description = "You are in a Forest! You know nothing about the Forest John!"
            };
            Room chamber = new Room()
            {
                Name = "Chamber",
                Description = "You are in a black chamber!"
            };

            King king = new King()
            {
                Name = "King",
                Description = "I'm the boss."
            };
            king.OnItemEmmit += (sender, item) =>
            {
                _inventory.Add(item);
                Ui.IndicateInventoryAddition(item);
            };
            king.OnDialogReply += (sender, message) =>
            {
                Ui.ShowTalk(message, sender as Character);    // results in NULL on invalid cast
            };

            chamber.NRooms.Add(forest);
            forest.NRooms.Add(chamber);

            forest.Characters.Add(king);

            CurrentRoom = forest;
        }

        public void Command_GO(Room newRoom)
        {
            var oldRoom = CurrentRoom;
            
            if (this.CurrentRoom.NRooms.Contains(newRoom)) CurrentRoom = newRoom;
            
            Ui.CurrentRoomTransition(oldRoom, newRoom);
        }

        public void Command_TALK(Character character)
        {
            character.Talk();
        }

        public void Command_Exit()
        {
            Ui.IndicateExit();
        }
    }
}