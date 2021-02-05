namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    public class NYPizzaIngredientFactory : IIngredientFactory
    {
        public Cheese CreateCheese()
        {
            throw new System.NotImplementedException();
        }

        public Clam CreateClams()
        {
            throw new System.NotImplementedException();
        }

        public Dough CreateDough()
        {
            throw new System.NotImplementedException();
        }

        public Pepperoni CreatePepperoni()
        {
            throw new System.NotImplementedException();
        }

        public Sauce CreateSauce()
        {
            throw new System.NotImplementedException();
        }

        public Veggie[] CreateVeggies()
        {
            throw new System.NotImplementedException();
        }
    }
}