using System;

namespace DesignPatterns.CoreObjects.StrategyPattern
{
    public abstract class Duck
    {
        public IFlyBehavior flyBehavior;
        public IQuackBehavior quackBehavior;
        public abstract void Display();

        public void Fly()
        {
            flyBehavior.Fly();
        }

        public void Quack()
        {
            quackBehavior.Quack();
        }
        public void Swim()
        {
            Console.WriteLine("All ducs float, even decoys!");
        }
    }

}