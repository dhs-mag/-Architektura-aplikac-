using Data;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Engine
{
    public class KQEngine
    {
        private Room currentRoom;
        public Room CurrentRoom { get => currentRoom; }
        public Player Hero { get; set; }
        
        public void GameInit()
        {
            
            //items
            Item sword = new Item() { Name = "Excalibur", Description = "Shiny, silver, deadly", type = ItemType.WEAPON};
            Item needle = new Item() { Name = "Needle", Description = "Thin, but can do hella circus", type = ItemType.WEAPON};
            Item money = new Item() { Name = "Money", Description = "Small but cute bag of gold", type = ItemType.MERCH};
            
            // Player - you 
            Player player = new Player();
            player.Items.Add(needle);
            player.Items.Add(money);
            Hero = player;    
            
            // persons
            Person Arthur = new Person() {Name = "Arthur", Story = "I am here to save the princess", nature = PersonType.FRIEND};
            Arthur.Items.Add(sword);
            Arthur.Items.Add(money);
            // rooms
            Room forest = new Room() { Name = "Forest", Description = "You are in a Forest! You know nothing John Forest!" };
            Room chamber = new Room() { Name = "Chamber", Description = "You are in a black chamber!" };
            chamber.NRooms.Add(forest);
            forest.NRooms.Add(chamber);
            forest.Persons.Add(Arthur);
            
            currentRoom = forest;
        }
        
        public void Command_GO(Room newRoom)
        {
            if (this.currentRoom.NRooms.Contains(newRoom)) currentRoom = newRoom;
        }

        public string Command_TALK(Person person)
        {
            return person.Story;
        }
        
        public string Command_USE(Item item, Person person)
        {
            if (item.type == ItemType.WEAPON)
            {
                switch (person.nature)
                {
                    case PersonType.FOE:
                        person.Stamina -= 10;
                        return $"You hit {person.Name} with {item.Name} and person's stamina is now equal to {person.Stamina}";
                    case PersonType.FRIEND:
                        return $"{person.Name} is not hostile, do not attack him!";
                    default:
                        return "";
                }
            }
            
            if (item.type == ItemType.POTION)
            {
                switch (person.nature)
                {
                    case PersonType.FOE:
                        return "Potion has no effect";
                    case PersonType.FRIEND:
                        person.Stamina += 10;
                        return $"{person.Name} is affected by {item.Name} and person's stamina is now equal to {person.Stamina}!";
                    default:
                        return "";
                }
            }

            return "";
        }

        
        public void Command_Exit()
        {
            //do something smart (save progres, etc.)
        }

    }
}
