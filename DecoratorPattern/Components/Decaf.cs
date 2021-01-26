namespace DesignPatterns.DecoratorPattern
{
    public class Decaf : IBeverage
    {
        public string Description { get; set; }
        public decimal Cost()
        {
            return 1.05m;
        }
    }
}