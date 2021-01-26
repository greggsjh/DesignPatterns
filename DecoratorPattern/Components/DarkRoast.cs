namespace DesignPatterns.DecoratorPattern
{
    public class DarkRoast : IBeverage
    {
        public string Description { get; set; }
        public decimal Cost()
        {
            return .99m;
        }
    }
}