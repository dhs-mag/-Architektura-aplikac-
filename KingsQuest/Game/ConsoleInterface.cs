using System;
using Data;
using Engine;

namespace Game
{
    public class ConsoleInterface : IUserInterface
    {
        public void ShowTalk(string dialogLine, Character whoIsTalking = null)
        {
            Console.WriteLine($"{whoIsTalking?.Name ?? "Someone"} says: {dialogLine}");
        }

        public void IndicateInventoryAddition(Item item)
        {
            Console.WriteLine("[" + item.Name + " was added to your inventory]");
        }
    }
}