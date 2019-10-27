using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Paths
        /// </summary>
        public List<Room> NRooms { get; set; }

        public Room()
        {
            NRooms = new List<Room>();
        }
    }
}
