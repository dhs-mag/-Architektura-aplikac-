using Engine;
using System;

namespace Game
{
    class Program
    {
        public static KQEngine Engine { get; set; }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Engine = new KQEngine();
            Engine.GameInit();
            Engine.Update();



            Console.ReadKey();
        }
    }
}
