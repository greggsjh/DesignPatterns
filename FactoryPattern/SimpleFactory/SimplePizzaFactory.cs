namespace DesignPatterns.FactoryPattern.SimplePizzaFactory
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(PizzaType type) //could be set as a static method
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.Clam:
                    pizza = new ClamPizza();
                    break;
                case PizzaType.Pepperoni:
                    pizza = new PepperoniPizza();
                    break;
                case PizzaType.Veggie:
                    pizza = new VeggiePizza();
                    break;
                default:
                    pizza = new CheesePizza();
                    break;
            }
            return pizza;
        }
    }

}