using System.Text;

namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal abstract class PizzaStore
    {
        internal Pizza OrderPizza(PizzaType type, out string message)
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

        internal abstract Pizza CreatePizza(PizzaType type);
    }
}