using Data;
using Engine;
using System;
using System.Collections;
using System.Linq;

namespace Game
{
    class Program
    {
        public static KQEngine Engine { get; set; }

        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();

            Engine = new KQEngine(ui);
            Engine.GameInit();

            bool quit = false;
            while (!quit)
            {
                Engine.PrintState();
                string input = Console.ReadLine();   
                
                switch (GetResxNameByValue(input.ToLower(), ui.Lang))
                {
                    case "cmd_go":
                        foreach (Room room in Engine.CurrentRoom.NRooms) Console.WriteLine($"{room.Name}");
                        Console.WriteLine($"{ui.Lang.GetString("CommandAnswerWhere")}:");
                        string newroom = Console.ReadLine();
                        Room newRoom = Engine.CurrentRoom.NRooms.Where(x => x.Name.ToLower() == newroom.ToLower()).First();
                        Engine.Command_GO(newRoom);
                        break;
                    case "cmd_talk":
                        foreach (Character charact in Engine.CurrentRoom.Characters) Console.WriteLine($"{charact.Name}");
                        Console.WriteLine($"{ui.Lang.GetString("CommandAnswerWho")}:");
                        string characterName = Console.ReadLine();
                        Character character = Engine.CurrentRoom.Characters.Where(x => x.Name.ToLower() == characterName.ToLower()).First();
                        Engine.Command_TALK(character);
                        break;
                    case "cmd_exit":
                        Engine.Command_Exit();
                        Console.WriteLine($"{ui.Lang.GetString("CommandAnswerEnd")}!");
                        quit = true;
                        break;
                    default:
                        //Console.WriteLine($"You wrote: {input}");
                        break;
                }
            }
            
            Console.ReadKey();
        }

        private static string GetResxNameByValue(string value, System.Resources.ResourceManager rm)
        {

            var entry =
                rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Value.ToString() == value);

            var key = entry.Key.ToString();
            return key;

        }
    }
}
