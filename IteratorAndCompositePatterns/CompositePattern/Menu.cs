using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.IteratorAndCompositePatterns.CompositePattern
{
    public class Menu : MenuComponent
    {
        List<MenuComponent> menuComponents = new List<MenuComponent>();

        public Menu(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.Append(Name);
            sb.AppendLine($", {Description}");
            sb.AppendLine("----------------");

            foreach (var item in menuComponents)
            {
                sb.AppendLine(item.Print());
            }

            return sb.ToString();
        }

        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }

        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }

        public override MenuComponent GetChild(int index)
        {
            return menuComponents[index];
        }
    }

}