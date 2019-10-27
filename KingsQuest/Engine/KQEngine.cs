using Data;
using System;

namespace Engine
{
    public class KQEngine
    {
        private Room currentRoom;

        public void PrintState()
        {
            //Console.WriteLine("You are in a Forest! You know nothing about the Forest John!");
            Console.WriteLine(currentRoom.Description);
        }

        public void GameInit()
        {
            Room forest = new Room() { Name = "Forest", Description = "You are in a Forest! You know nothing about the Forest John!" };
            Room chamber = new Room() { Name = "Chamber", Description = "You are in a black chamber!" };
            chamber.NRooms.Add(forest);
            forest.NRooms.Add(chamber);
            currentRoom = forest;
        }

        public void Update()
        {
            bool quit = false;
            while (!quit)
            {
                //Console.Clear();
                PrintState();
                string input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "exit": quit = true;
                        break;
                    default: Console.WriteLine($"You wrote: {input}");
                        break;
                }
            }
        }
    }
}
