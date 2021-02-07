namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal class ChicagoPizzaStore : PizzaStore
    {
        internal override Pizza CreatePizza(PizzaType type)
        {
            return new ChicagoStyleCheesePizza();
        }
    }
}