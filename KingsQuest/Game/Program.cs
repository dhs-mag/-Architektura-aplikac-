using Data;
using Engine;
using System;
using System.Linq;
using System.Runtime;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleInterface();
            
            ui.MainLoop();
            
            Console.ReadKey();
        }
    }
}
