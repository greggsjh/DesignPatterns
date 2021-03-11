namespace DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod
{
    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(PizzaType type)
        {
            return new NYStyleCheesePizza();
        }
    }
}