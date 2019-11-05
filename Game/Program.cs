using Data;
using Engine;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Game
{
    class Program
    {
        public static KQEngine Engine { get; set; }
        

        static void Main(string[] args)
        {
            Engine = new KQEngine();
            Engine.GameInit();

            bool quit = false;
            while (!quit)
            {
                // gameInfo
                Console.WriteLine(Engine.CurrentRoom.Description);
                string RoomPersons = getRoomPersons();
                Console.WriteLine(RoomPersons != null ? $"Persons in the room: {RoomPersons}" : "You are alone in the room...");
                Console.WriteLine($"Possible routes: {getPossibleRoutes()}");
                Console.WriteLine($"Your items: {getItems()}");
                Console.WriteLine();
                Console.WriteLine(getGameInterface());
                
                string input = Console.ReadLine();
                
                Console.WriteLine("==========================");
                parseCommand(input);
                Console.WriteLine("==========================");
            }
        }

        public static void parseCommand(string input)
        {
            string[] buffer = input.Split(' ');
            string command = buffer[0].ToLower();
            if (command == "go")
            {
                if (buffer.Length > 1)
                {
                    Room newRoom = Engine.CurrentRoom.NRooms.First(x => x.Name.ToLower() == buffer[1].ToLower());
                    Engine.Command_GO(newRoom);    
                }
            }
            if (command == "talk")
            {
                if (buffer.Length > 1)
                {
                    Person person = Engine.CurrentRoom.Persons.First(p => p.Name.ToLower() == buffer[1].ToLower());
                    Console.WriteLine(Engine.Command_TALK(person));
                }
            }
            if (command == "use")
            {
                if (buffer.Length > 2)
                {
                    Item item = Engine.Hero.Items.First(i => i.Name.ToLower() == buffer[1].ToLower());
                    Person person = Engine.CurrentRoom.Persons.First(p => p.Name.ToLower() == buffer[2].ToLower());
                    Console.WriteLine(Engine.Command_USE(item, person));
                }
            }
            Console.WriteLine();
        }
        
        public static string getPossibleRoutes()
        {
            string routes = "";
            foreach (Room room in Engine.CurrentRoom.NRooms)
            {
                routes += room.Name;
            }

            return routes.Length > 0 ? routes : null;
        }

        public static string getRoomPersons()
        {
            string persons = "";
            foreach (Person person in Engine.CurrentRoom.Persons)
            {
                persons += person.Name + " ";
            }

            return persons.Length > 0 ? persons : null;
        }

        public static string getItems()
        {
            string output = "";
            foreach (Item item in Engine.Hero.Items)
            {
                output += item.Name + " ";
            }

            return output;
        }
        public static string getGameInterface()
        {
            string output = "Possible commands are:\n go <Room>\n talk <Person>\n use <Item> <Person>";
            return output;
        }
    }
}
