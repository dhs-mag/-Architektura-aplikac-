using System.Collections.Generic;
using Data.Things.Contract;

namespace Data
{
    public class Player
    {
        public Inventory<IPickable> Inventory {get; private set; }

        public Player(int inventoryCapacity)
        {
            Inventory = new Inventory<IPickable>(inventoryCapacity);
        }
    }
}