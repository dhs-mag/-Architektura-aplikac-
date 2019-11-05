using System.Collections.Generic;

namespace Data
{
    public class Player
    {
        public int Stamina { get; set; }
        
        public List<Item> Items { get; set; }

        public Player()
        {
            Items = new List<Item>();
            Stamina = 20;
        }
    }
}