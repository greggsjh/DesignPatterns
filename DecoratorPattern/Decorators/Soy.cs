namespace DesignPatterns.DecoratorPattern
{
    public class Soy : IBeverage
    {
        public IBeverage Beverage { get; set; }
        public string Description { get; set; }
        public decimal Cost()
        {
            return Beverage.Cost() + .15m;
        }
    }
}