using System.Collections;

namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public class PancakeHouseMenu : IEnumerable
    {
        private ArrayList MenuItems { get; set; }

        public PancakeHouseMenu()
        {
            MenuItems = new ArrayList();

            addItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99m);
            addItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99m);
            addItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49m);
            addItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59m);
        }

        private void addItem(string name, string description, bool isVegetarian, decimal price)
        {
            MenuItems.Add(new MenuItem(name, description, isVegetarian, price));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in MenuItems)
            {
                yield return item;
            }
        }
    }
}