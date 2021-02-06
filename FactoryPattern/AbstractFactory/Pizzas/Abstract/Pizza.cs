namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal abstract class Pizza
    {
        public string Name { get; set; }
        public Dough Dough { get; set; }
        public Sauce Sauce { get; set; }
        public Veggie[] Veggies { get; set; }
        public Cheese Cheese { get; set; }
        public Pepperoni Pepperoni { get; set; }
        public Clam Clam { get; set; }

        internal abstract string Prepare();

        internal void Bake()
        {

        }

        internal void Cut()
        {

        }

        internal void Box()
        {

        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}