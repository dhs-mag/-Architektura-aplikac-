using Engine;
using System;

namespace Game
{
    class Program
    {
        private static GameEngine Engine { get; set; }

        private static void Main(string[] args)
        {
            Engine = new GameEngine();
            Engine.GameInit();
            Engine.Update();

            Console.ReadKey();
        }
    }
}
