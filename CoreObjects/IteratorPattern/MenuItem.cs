namespace DesignPatterns.CoreObjects.IteratorPattern
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Vegetarian { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, string desc, bool veg, decimal price)
        {
            Name = name;
            Description = desc;
            Vegetarian = veg;
            Price = price;
        }
    }
}