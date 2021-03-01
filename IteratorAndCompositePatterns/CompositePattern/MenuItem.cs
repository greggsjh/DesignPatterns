using System.Text;

namespace DesignPatterns.IteratorAndCompositePatterns.CompositePattern
{
    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string desc, bool vegetarian, decimal price)
        {
            Name = name;
            Description = desc;
            IsVegetarian = vegetarian;
            Price = price;
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($" {Name}");
            if (IsVegetarian)
            {
                sb.Append("(v)");
            }

            sb.AppendLine($", {Price}");
            sb.AppendLine($"    -- {Description}");

            return sb.ToString();
        }
    }
}