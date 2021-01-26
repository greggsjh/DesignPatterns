namespace DesignPatterns.DecoratorPattern
{
    public class Mocha : IBeverage
    {
        public IBeverage Beverage { get; set; }
        public string Description { get; set; }
        public decimal Cost()
        {
            return Beverage.Cost() + .20m;
        }
    }
}