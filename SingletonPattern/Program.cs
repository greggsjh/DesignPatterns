using System;
using DesignPatterns.SingletonPattern;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ChocolateBoiler chocolateBoiler = ChocolateBoiler.Instance;

            Console.WriteLine(chocolateBoiler.Fill());
            Console.WriteLine(chocolateBoiler.Boil());
            Console.WriteLine(chocolateBoiler.Drain());
        }
    }
}
