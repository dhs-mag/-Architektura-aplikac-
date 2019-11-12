using System;
using System.Linq;
using Data;
using Engine;

namespace Game
{
    public class ConsoleInterface : IUserInterface
    {
        private readonly KQEngine Engine;

        public ConsoleInterface()
        {
            Engine = new KQEngine(this);
            Engine.GameInit();
        }

        public void ShowTalk(string dialogLine, Character whoIsTalking = null)
        {
            Console.WriteLine($"{whoIsTalking?.Name ?? "Someone"} says: {dialogLine}");
        }

        public void IndicateInventoryAddition(Item item)
        {
            Console.WriteLine("[" + item.Name + " was added to your inventory]");
            DescribePlayer();
        }

        public void CurrentRoomTransition(Room oldRoom, Room newRoom)
        {
            Console.WriteLine($"[You have moved from {oldRoom.Name} to {newRoom.Name}]");
            DescribeCurrentLocation();
        }

        public void IndicateExit()
        {
            Console.WriteLine("Game over!");
        }

        private void DescribeCurrentLocation()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(Engine.CurrentRoom.Description);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Characters around you: " + string.Join(",", Engine.CurrentRoom.Characters.Select(c => c.Name)));
            Console.WriteLine("You can go to:  " + string.Join(",", Engine.CurrentRoom.NRooms.Select(c => c.Name)));
        }

        private void DescribePlayer()
        {
            Console.WriteLine("You now have: " + string.Join(",", Engine.Inventory.Select(i => i.Name)));
        }

        public void MainLoop()
        {
            Engine.GameInit();

            DescribeCurrentLocation();
            DescribePlayer();

            var quit = false;
            while (!quit)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "go":

                        Console.Write("Where to? > ");
                        var roomNameInput = Console.ReadLine();
                        var newRoom =
                            Engine.CurrentRoom.NRooms.FirstOrDefault(x => x.Name.ToLower() == roomNameInput?.ToLower());
                        if (newRoom == null)
                        {
                            Console.Write("I do not understand. There are: ");
                            foreach (var room in Engine.CurrentRoom.NRooms) Console.Write($"{room.Name}");
                            Console.WriteLine();
                            break;
                        }
                        Engine.Command_GO(newRoom);
                        break;
                    case "talk":
                        Console.Write("To whom? > ");
                        var characterNameInput = Console.ReadLine();
                        Character character =
                            Engine.CurrentRoom.Characters.FirstOrDefault(x =>
                                x.Name.ToLower() == characterNameInput?.ToLower());

                        if (character == null)
                        {
                            Console.Write("I do not understand. There are: ");
                            foreach (var room in Engine.CurrentRoom.Characters) Console.Write($"{room.Name}");
                            Console.WriteLine();
                            break;
                        }
                        Engine.Command_TALK(character);
                        break;
                    case "exit":
                        Engine.Command_Exit();
                        quit = true;
                        break;
                    default:
                        Console.WriteLine($"You wrote: {input}\n Available commands: go, talk, exit");
                        break;
                }
            }
        }
    }
}