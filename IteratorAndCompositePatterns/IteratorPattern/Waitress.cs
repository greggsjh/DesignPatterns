using System.Collections;
using System.Text;

namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public class Waitress
    {
        private IMenu[] menus;

        public Waitress(IMenu[] m)
        {
            menus = m;
        }

        public string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MENU");
            sb.AppendLine("----");

            foreach (var item in menus)
            {
                sb.AppendLine(item.Name);
                sb.AppendLine(PrintMenu(item));
            }

            return sb.ToString();
        }

        private string PrintMenu(IEnumerable enumerable)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in enumerable)
            {
                MenuItem i = (MenuItem)item;
                sb.AppendLine($"{i.Name}, {i.Price} -- {i.Description}");
            }
            return sb.ToString();
        }
    }
}