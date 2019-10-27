using Data;
using System;
using System.Linq;

namespace Engine
{
    public class GameEngine
    {
        private Room CurrentRoom;

        private void PrintState()
        {
            Console.WriteLine(CurrentRoom.Description);
            if (CurrentRoom.RoomsAround.Any())
            {
                Console.WriteLine("\nAround you are:");
                for (var index = 0; index < CurrentRoom.RoomsAround.Count; index++)
                {
                    var room = CurrentRoom.RoomsAround[index];
                    Console.WriteLine("{0}) {1}", index + 1, room.Name);
                }

                Console.WriteLine("\nType number to move.");
            }
            else
            {
                Console.WriteLine("\nThere is nothing around you.");
            }
        }

        public void GameInit()
        {
            Room forest = new Room() { Name = "Forest", Description = "You are in a Forest! You know nothing about the Forest John!" };
            Room chamber = new Room() { Name = "Chamber", Description = "You are in a black chamber!" };
            
            chamber.RoomsAround.Add(forest);
            forest.RoomsAround.Add(chamber);
            
            CurrentRoom = forest;
        }

        public void Update()
        {
            var quit = false;
            while (!quit)
            {
                PrintState();
                
                var input = Console.ReadLine();
                if (input == null)
                    continue;

                if (int.TryParse(input, out var number))
                {
                    if (number < 1 || number > CurrentRoom.RoomsAround.Count)
                    {
                        Console.WriteLine("There's no such room, try again.\n");
                        continue;
                    } 
                    var nextRoom = CurrentRoom.RoomsAround[number - 1];
                    CurrentRoom = nextRoom;
                    continue;
                }
                
                
                switch(input.ToLower())
                {
                    case "exit":
                        quit = true;
                        break;
                    default: Console.WriteLine($"You wrote: {input}");
                        break;
                }
            }
        }
    }
}
