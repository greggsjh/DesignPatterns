namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal abstract class PizzaStore
    {
        internal Pizza OrderPizza(PizzaType type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        internal abstract Pizza CreatePizza(PizzaType type);
    }
}