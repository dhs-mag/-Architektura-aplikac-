using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Room : GameObject
    {
        /// <summary>
        /// Paths
        /// </summary>
        public List<Room> NRooms { get; set; }

        public List<Item> Items { get; set; }

        public List<Character> Characters { get; set; }

        public Room()
        {
            NRooms = new List<Room>();
            Items = new List<Item>();
            Characters = new List<Character>();
        }
    }
}
