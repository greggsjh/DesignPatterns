using System;

namespace DesignPatterns.CoreObjects.DecoratorPattern
{
    public class Espresso : IBeverage
    {
        public string Description { get { return "Espresso"; } }
        public CoffeeSize Size { get; set; }
        public Espresso()
        {

        }
        public Espresso(CoffeeSize size)
        {
            Size = size;
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

            return Math.Round(1.99m * multiplier, 2);
        }
    }
}