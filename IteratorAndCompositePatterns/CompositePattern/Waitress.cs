using System.Text;

namespace DesignPatterns.IteratorAndCompositePatterns.CompositePattern
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