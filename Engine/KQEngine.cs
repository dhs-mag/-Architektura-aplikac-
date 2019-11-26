using Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Engine
{
    public interface IUserInterface
    {
        public System.Resources.ResourceManager Lang { get; }

        void ShowTalk(Character sender, string message);
        void ItemAdd(Item item);
        void PrintState(KQEngine engine);
    }

    public class KQEngine
    {
        private Room currentRoom;
        public Room CurrentRoom { get => currentRoom; }

        public List<Item> Inventory { get; set; }

        private IUserInterface _ui;

        public KQEngine(IUserInterface ui)
        {
            Inventory = new List<Item>();
            _ui = ui;
        }

        public void PrintState()
        {
            _ui.PrintState(this);
        }

        public void GameInit()
        {
            CultureInfo ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
            //Console.WriteLine($"Lang: {CultureInfo.CurrentCulture.DisplayName}");

            Room forest = new Room() { Name = _ui.Lang.GetString("RoomForrestName"), Description = _ui.Lang.GetString("RoomForrestDescription") };
            Room chamber = new Room() { Name = _ui.Lang.GetString("RoomChamberName"), Description = _ui.Lang.GetString("RoomChamberDescription") };

            King king = new King() { Name = _ui.Lang.GetString("CharacterKingName"), Description = _ui.Lang.GetString("CharacterKingDescription") };
            forest.Characters.Add(king);
            king.NewItemEvent += NewItemEvent;
            king.TalkEvent += TalkEvent;

            chamber.NRooms.Add(forest);
            forest.NRooms.Add(chamber);
            currentRoom = forest;
        }

        private void TalkEvent(object sender, string key)
        {
            _ui.ShowTalk((Character)sender, key);
        }

        private void NewItemEvent(object sender, Item item)
        {
            Inventory.Add(item);
            _ui.ItemAdd(item);
        }

        //public void Update(GameCommand input)
        //{
        //    switch (input)
        //    {
        //        case GameCommand.GO:
        //            Command_GO();
        //            break;
        //        case GameCommand.EXIT:
        //            Command_Exit();
        //            break;
        //        default:
        //            //Console.WriteLine($"You wrote: {input}");
        //            break;
        //    }
        //}


        public void Command_GO(Room newRoom)
        {
            if (this.currentRoom.NRooms.Contains(newRoom)) currentRoom = newRoom;
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
