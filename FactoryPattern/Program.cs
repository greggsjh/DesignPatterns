using System;

namespace DesignPatterns.FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryMethod.PizzaStore nyPizzaStore = new FactoryMethod.NYPizzaStore();
            FactoryMethod.ChicagoPizzaStore chicagoPizzaStore = new FactoryMethod.ChicagoPizzaStore();

            string message;
            FactoryMethod.Pizza pizza = nyPizzaStore.OrderPizza(PizzaType.Cheese, out message);
            Console.Write(message);
            Console.WriteLine($"Ethan ordered a {pizza.Name} \n");

            string messageOne;
            FactoryMethod.Pizza pizzaOne = chicagoPizzaStore.OrderPizza(PizzaType.Cheese, out messageOne);
            Console.Write(messageOne);
            Console.WriteLine($"Joel ordered a {pizzaOne.Name} \n");
        }
    }
}
