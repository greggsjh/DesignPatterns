using System;

namespace DesignPatterns.CoreObjects.StrategyPattern
{
    public class PlainQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }
}