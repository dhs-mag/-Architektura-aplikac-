using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    enum ItemType { Weapon, Other };

    public class Item : GameObject
    {
        ItemType Type { get; set; }
    }
}
