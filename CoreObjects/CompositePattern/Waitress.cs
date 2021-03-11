using System.Text;

namespace DesignPatterns.CoreObjects.CompositePattern
{
    public class Waitress
    {
        MenuComponent _allMenus;

        public Waitress(MenuComponent allMenus)
        {
            _allMenus = allMenus;
        }

        public string PrintMenu()
        {
            return _allMenus.Print();
        }
    }
}