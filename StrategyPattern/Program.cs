using System;

namespace DesignPatterns.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Mallard mallard = new Mallard();
            mallard.Fly();
            mallard.Quack();
            Console.ReadLine();

            Duck model = new ModelDuck();
            model.Fly();
            (model as ModelDuck).FlyBehavior = new FlyRocketPowered();
            model.Fly();
        }
    }
}
