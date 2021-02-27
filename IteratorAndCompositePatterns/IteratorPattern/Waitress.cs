using System.Collections;
using System.Text;

namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public class Waitress
    {
        private IEnumerable dinerMenu;
        private IEnumerable pancakeHouseMenu;
        private IEnumerable cafeMenu;

        public Waitress(IEnumerable dMenu, IEnumerable pHouseMenu, IEnumerable cMenu)
        {
            dinerMenu = dMenu;
            pancakeHouseMenu = pHouseMenu;
            cafeMenu = cMenu;
        }

        public string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MENU");
            sb.AppendLine("----");
            sb.AppendLine("BREAKFAST");
            sb.AppendLine(PrintMenu(pancakeHouseMenu));
            sb.AppendLine("LUNCH");
            sb.AppendLine(PrintMenu(dinerMenu));
            sb.AppendLine("DINNER");
            sb.AppendLine(PrintMenu(cafeMenu));

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