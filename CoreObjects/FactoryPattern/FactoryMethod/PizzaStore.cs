using System.Text;

namespace DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaType type, out string message)
        {
            StringBuilder sb = new StringBuilder();
            Pizza pizza = CreatePizza(type);

            sb.AppendLine(pizza.Prepare());
            sb.AppendLine(pizza.Bake());
            sb.AppendLine(pizza.Cut());
            sb.AppendLine(pizza.Box());

            message = sb.ToString();

            return pizza;
        }

        public abstract Pizza CreatePizza(PizzaType type);
    }
}