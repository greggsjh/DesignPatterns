namespace DesignPatterns.CoreObjects.FactoryPattern.AbstractFactory
{
    public interface IIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreateCheese();
        Veggie[] CreateVeggies();
        Pepperoni CreatePepperoni();
        Clam CreateClams();
    }
}