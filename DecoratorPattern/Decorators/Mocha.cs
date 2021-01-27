using System;

namespace DesignPatterns.DecoratorPattern
{
    public class Mocha : IBeverage
    {
        private IBeverage Beverage { get; set; }
        public string Description { get { return Beverage.Description + ", Mocha"; } }
        public CoffeeSize Size { get; set; }
        public Mocha(IBeverage beverage)
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

            return Math.Round(Beverage.Cost() + (.20m * multiplier), 2);
        }
    }
}