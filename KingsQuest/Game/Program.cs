using Data;
using Engine;
using System;
using System.Linq;
using System.Runtime;

namespace Game
{
    class Program
    {
        private static KQEngine Engine { get; set; }

        static void Main(string[] args)
        {
            var ui = new ConsoleInterface();
            
            Engine = new KQEngine(ui);
            Engine.GameInit();

            Engine.PrintState();
                
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
                        var newRoom = Engine.CurrentRoom.NRooms.FirstOrDefault(x => x.Name.ToLower() == roomNameInput?.ToLower());
                        if (newRoom == null)
                        {
                            Console.Write("I do not understand. There are: ");
                            foreach (var room in Engine.CurrentRoom.NRooms) Console.Write($"{room.Name}");
                            Console.WriteLine();
                            break;
                        }

                        Engine.Command_GO(newRoom);
                        Engine.PrintState();
                        break;
                    case "talk":
                        Console.Write("To whom? > ");
                        var characterNameInput = Console.ReadLine();
                        Character character = Engine.CurrentRoom.Characters.FirstOrDefault(x => x.Name.ToLower() == characterNameInput?.ToLower());
                        
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
                        Console.WriteLine("Game over!");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine($"You wrote: {input}\n Available commands: go, talk, exit");
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}
