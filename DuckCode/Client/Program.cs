using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Mallard mallard = new Mallard();
            mallard.Fly();
            mallard.Quack();
            Console.ReadLine();
        }
    }
}
