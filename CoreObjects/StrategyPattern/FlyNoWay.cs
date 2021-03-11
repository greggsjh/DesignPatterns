using System;

namespace DesignPatterns.CoreObjects.StrategyPattern
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly...");
        }
    }
}