namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal class NYPizzaStore : PizzaStore
    {
        internal override Pizza CreatePizza(PizzaType type)
        {
            return new NYStyleCheesePizza();
        }
    }
}