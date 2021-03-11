namespace DesignPatterns.CoreObjects.FactoryPattern.AbstractFactory
{
    internal class ChicagoPizzaIngredientFactory : IIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public Clam CreateClams()
        {
            return new FrozenClam();
        }

        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public Veggie[] CreateVeggies()
        {
            return new Veggie[] { new Spinach(), new BlackOlive(), new Eggplant() };
        }
    }
}