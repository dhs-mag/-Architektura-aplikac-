using System;
using Engine;

namespace Game
{
    public class ConsoleInterface : IUserInterface
    {
        public void ShowTalk()
        {
            Console.WriteLine("show talk method");
        }
    }
}