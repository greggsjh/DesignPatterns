using System;

namespace DesignPatterns.DecoratorPattern
{
    public class Decaf : IBeverage
    {
        public string Description { get { return "Decaf"; } }
        public CoffeeSize Size { get; set; }
        public Decaf()
        {
        }
        public Decaf(CoffeeSize size)
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

            return Math.Round(1.05m * multiplier, 2);
        }
    }
}