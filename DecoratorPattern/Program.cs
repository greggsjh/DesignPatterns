using System;
using DesignPatterns.DecoratorPattern;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IBeverage beverage = new Espresso(CoffeeSize.Tall);
            Console.WriteLine("{0} $ {1}", beverage.Description, beverage.Cost());

            IBeverage beverage1 = new DarkRoast(CoffeeSize.Tall);
            beverage1 = new Mocha(beverage1);
            beverage1 = new Mocha(beverage1);
            beverage1 = new Whip(beverage1);
            Console.WriteLine($"{beverage1.Description} $ {beverage1.Cost()}");

            IBeverage beverage2 = new HouseBlend(CoffeeSize.Tall);
            beverage2 = new Soy(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.Description} $ {beverage2.Cost()}");
        }
    }
}
