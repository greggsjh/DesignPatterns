namespace DesignPatterns.CoreObjects.FactoryPattern.AbstractFactory
{
    public class NYPizzaIngredientFactory : IIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public Clam CreateClams()
        {
            return new FreshClam();
        }

        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Veggie[] CreateVeggies()
        {
            return new Veggie[] { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
        }
    }
}