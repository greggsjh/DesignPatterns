namespace DesignPatterns.DecoratorPattern
{
    public class HouseBlend : IBeverage
    {
        public string Description { get; set; }

        public decimal Cost()
        {
            return .89m;
        }
    }
}