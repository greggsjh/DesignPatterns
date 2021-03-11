namespace DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod
{
    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(PizzaType type)
        {
            return new ChicagoStyleCheesePizza();
        }
    }
}