using System.Collections.Generic;
using Data.Things.Contract;

namespace Data
{
    public class Inventory<TContent>
    {
        // ReSharper disable once InconsistentNaming
        private readonly List<TContent> _inventory;

        public int Capacity { get; private set; }

        public bool CanAdd => _inventory.Count < Capacity;

        public TContent[] Contents => _inventory.ToArray();
        
        public Inventory(int capacity)
        {
            Capacity = capacity;
            _inventory = new List<TContent>(Capacity);
        }

        public bool Add(TContent thing)
        {
            if (!CanAdd) return false;
            _inventory.Add(thing);
            return true;
        }
    }
}