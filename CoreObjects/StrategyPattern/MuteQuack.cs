using System;

namespace DesignPatterns.CoreObjects.StrategyPattern
{
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<<Silence>>");
        }
    }
}