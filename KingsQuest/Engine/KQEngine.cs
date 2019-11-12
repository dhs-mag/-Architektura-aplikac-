using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class KQEngine
    {
        public Room CurrentRoom { get; private set; }

        public List<Item> Inventory { get; set; }

        private readonly IUserInterface Ui;

        public KQEngine(IUserInterface ui)
        {
            Ui = ui;
            Inventory = new List<Item>();
        }

        public void PrintState()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(CurrentRoom.Description);
            Console.WriteLine("Around you are: " + string.Join(",", CurrentRoom.Characters.Select(c => c.Name)));
            Console.WriteLine("You have:" + string.Join(",", Inventory.Select(i => i.Name)));
            Console.WriteLine("You can go to:  " + string.Join(",", CurrentRoom.NRooms.Select(c => c.Name)));
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
                Inventory.Add(item);
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
            if (this.CurrentRoom.NRooms.Contains(newRoom)) CurrentRoom = newRoom;
        }

        public void Command_TALK(Character character)
        {
            character.Talk();
        }

        public void Command_Exit()
        {
            //do something smart (save progres, etc.)
        }
    }
}