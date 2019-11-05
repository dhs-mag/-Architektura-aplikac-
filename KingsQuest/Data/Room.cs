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
        public List<Room> RoomsAround { get; set; }
        
        public List<Thing> ThingsInside { get; set; }

        public Room()
        {
            RoomsAround = new List<Room>();
            ThingsInside = new List<Thing>();
        }
    }
}
