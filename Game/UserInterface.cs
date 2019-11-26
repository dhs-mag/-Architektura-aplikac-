using Data;
using Engine;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Resources;
using System.Text;

namespace Game
{
    public class UserInterface : Engine.IUserInterface
    {

        public ResourceManager Lang { get => Resource1.ResourceManager; }


        public void ItemAdd(Item item)
        {
            Console.WriteLine($"|| {this.Lang.GetString("StateNewItem")}: {item.Name}.||");
        }

        public void ShowTalk(Character sender, string key)
        {

            //if (!dict.ContainsKey(key))
            //{
            //    Console.WriteLine($"ERROR: Not existing translation - {key}");
            //};
            Console.WriteLine($"{this.Lang.GetString("TalkAnswer")}: {this.Lang.GetString(key)}");
        }


        public void PrintState(KQEngine engine)
        {
            
            Console.WriteLine("|=====================");
            Console.WriteLine($"|>{this.Lang.GetString("StateAroundYou")}:");
            Console.WriteLine("| " + engine.CurrentRoom.Description);
            Console.WriteLine("|---------------------");
            Console.WriteLine($"|>{this.Lang.GetString("StateSeeInside")}:");
            Console.Write("| ");
            foreach (Character character in engine.CurrentRoom.Characters)
                Console.Write(character.Name);
            Console.WriteLine();
            Console.WriteLine("|---------------------");
            Console.WriteLine($"|>{this.Lang.GetString("StateYouHave")}:");
            Console.Write("| ");
            foreach (Item item in engine.Inventory)
                Console.Write(item.Name);
            Console.WriteLine();
            Console.WriteLine("|=====================");
        }

    }
}
