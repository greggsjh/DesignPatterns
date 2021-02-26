using System.Collections;
using System.Text;
namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public class Waitress
    {
        private DinerMenu dinerMenu;
        private PancakeHouseMenu pancakeHouseMenu;

        public Waitress(DinerMenu dMenu, PancakeHouseMenu pHouseMenu)
        {
            dinerMenu = dMenu;
            pancakeHouseMenu = pHouseMenu;
        }

        public string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MENU");
            sb.AppendLine("----");
            sb.AppendLine("BREAKFAST");
            sb.AppendLine(PrintMenu(dinerMenu));
            sb.AppendLine("LUNCH");
            sb.AppendLine(PrintMenu(pancakeHouseMenu));

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