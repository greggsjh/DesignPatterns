using System;

namespace DesignPatterns.CoreObjects.DecoratorPattern
{
    public class Milk : IBeverage
    {
        private IBeverage Beverage { get; set; }
        public string Description { get { return Beverage.Description + ", Milk"; } }
        public CoffeeSize Size { get; set; }
        public Milk(IBeverage beverage)
        {
            Beverage = beverage;
            Size = beverage.Size;
        }
        public decimal Cost()
        {
            decimal multiplier = 1;
            switch (Size)
            {
                case CoffeeSize.Tall:
                    multiplier = .66m;
                    break;
                case CoffeeSize.Venti:
                    multiplier = 1.33m;
                    break;
            }

            return Math.Round(Beverage.Cost() + (.10m * multiplier), 2);
        }
    }
}