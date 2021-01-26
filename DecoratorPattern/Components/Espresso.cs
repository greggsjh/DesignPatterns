namespace DesignPatterns.DecoratorPattern
{
    public class Espresso : IBeverage
    {
        public string Description { get; set; }
        public decimal Cost()
        {
            return 1.99m;
        }
    }
}