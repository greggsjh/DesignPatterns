using System;

namespace DesignPatterns.StrategyPattern
{
    public class ModelDuck : Duck
    {
        public IFlyBehavior FlyBehavior
        {
            get { return flyBehavior; }
            set { flyBehavior = value; }
        }
        public IQuackBehavior QuackBehavior
        {
            get { return quackBehavior; }
            set { quackBehavior = value; }
        }

        public ModelDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new PlainQuack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck.");
        }
    }
}