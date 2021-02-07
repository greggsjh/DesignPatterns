namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal class NYPizzaStore : PizzaStore
    {
        internal override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            IIngredientFactory IngredientFactory = new NYPizzaIngredientFactory();

            switch (type)
            {
                case PizzaType.Veggie:
                    pizza = new VeggiePizza(IngredientFactory);
                    pizza.Name = "New York Style Veggie Pizza";
                    break;
                case PizzaType.Clam:
                    pizza = new ClamPizza(IngredientFactory);
                    pizza.Name = "New York Style Clam Pizza";
                    break;
                case PizzaType.Pepperoni:
                    pizza = new PepperoniPizza(IngredientFactory);
                    pizza.Name = "New York Style Pepperoni Pizza";
                    break;
                default:
                    pizza = new CheezePizza(IngredientFactory);
                    pizza.Name = "New York Style Cheese Pizza";
                    break;
            }

            return pizza;
        }
    }
}