using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod
{
    public abstract class Pizza
    {
        public string Name { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; }

        public string Prepare()
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

        public virtual string Bake()
        {
            return "Bake for 25 minutes at 350";
        }

        public virtual string Cut()
        {
            return "Cutting the pizza into diagonal slices";
        }

        public virtual string Box()
        {
            return "Place pizza in official PizzaStore box";
        }
    }
}