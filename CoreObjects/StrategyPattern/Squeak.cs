using System;

namespace DesignPatterns.CoreObjects.StrategyPattern
{
    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak");
        }
    }
}