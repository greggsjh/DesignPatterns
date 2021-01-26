namespace DesignPatterns.DecoratorPattern
{
    public class Milk : IBeverage
    {
        public IBeverage Beverage { get; set; }
        public string Description { get; set; }
        public decimal Cost()
        {
            return Beverage.Cost() + .10m;
        }
    }
}