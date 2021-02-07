namespace DesignPatterns.FactoryPattern.SimplePizzaFactory
{
    public class PizzaStore
    {
        private SimplePizzaFactory factory; //not needed if SimplePizzaFactory.CreatePizza is a static method

        public PizzaStore(SimplePizzaFactory f)
        {
            factory = f;
        }

        public Pizza OrderPizza(PizzaType type)
        {
            Pizza pizza = factory.CreatePizza(type);  //can be a static call without the need of an instance

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }
}