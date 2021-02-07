using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal abstract class Pizza
    {
        internal string Name { get; set; }
        internal string Dough { get; set; }
        internal string Sauce { get; set; }
        internal List<string> Toppings { get; set; }

        internal string Prepare()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Preparing {Name}");
            sb.AppendLine("Tossing dough...");
            sb.AppendLine("Adding sauce...");
            sb.AppendLine("Adding toppings: ");
            foreach (var topping in Toppings)
            {
                sb.Append($" {topping}");
            }
            return sb.ToString();
        }

        internal virtual string Bake()
        {
            return "Bake for 25 minutes at 350";
        }

        internal virtual string Cut()
        {
            return "Cutting the pizza into diagonal slices";
        }

        internal virtual string Box()
        {
            return "Place pizza in official PizzaStore box";
        }
    }
}