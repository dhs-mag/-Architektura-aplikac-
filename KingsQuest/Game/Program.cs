using Engine;
using System;

namespace Game
{
    class Program
    {
        private static GameEngine Engine { get; set; }

        private static void Main(string[] args)
        {
            Engine = new GameEngine();
            Engine.GameInit();
            
            
            var quit = false;
            var doPrintDescription = true;
            while (!quit)
            {
                if (doPrintDescription)
                {
                    Console.WriteLine(Engine.GetStateDescription());
                }
                
                var input = Console.ReadLine();
                if (input == null)
                {
                    doPrintDescription = false;
                    continue;
                }

                if (int.TryParse(input, out var number))
                {
                    if (number < 1 || number > Engine.AdjacentRooms.Count)
                    {
                        Console.WriteLine("There's no such room, try again.");
                        doPrintDescription = false;
                        continue;
                    } 
                    var success = Engine.MoveTo(Engine.AdjacentRooms[number - 1]);
                    if (!success)
                    {
                        Console.WriteLine("There's no such room, try again.");
                        doPrintDescription = false;
                        continue;
                    }

                    doPrintDescription = true;
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
            
            Console.ReadKey();
        }
    }
}
