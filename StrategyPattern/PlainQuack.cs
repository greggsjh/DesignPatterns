using System;

namespace DesignPatterns.StrategyPattern
{
    public class PlainQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }
}