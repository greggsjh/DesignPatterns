using System;

namespace DesignPatterns.CoreObjects.DecoratorPattern
{
    public class DarkRoast : IBeverage
    {
        public string Description { get { return "Dark Roast"; } }
        public CoffeeSize Size { get; set; }
        public DarkRoast()
        {

        }
        public DarkRoast(CoffeeSize size)
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

            return Math.Round(.99m * multiplier, 2);
        }
    }
}