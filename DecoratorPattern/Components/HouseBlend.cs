using System;

namespace DesignPatterns.DecoratorPattern
{
    public class HouseBlend : IBeverage
    {
        public string Description { get { return "House Blend"; } }

        public CoffeeSize Size { get; set; }
        public HouseBlend()
        {

        }
        public HouseBlend(CoffeeSize size)
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

            return Math.Round(.89m * multiplier, 2);
        }
    }
}