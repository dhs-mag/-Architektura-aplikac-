using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public enum ItemType
    {
        Weapon,
        Other
    };

    public class Item : GameObject
    {
        public ItemType Type { get; set; }
    }
}