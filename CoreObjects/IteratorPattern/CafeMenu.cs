using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.CoreObjects.IteratorPattern
{
    public class CafeMenu : IMenu
    {
        private Dictionary<string, MenuItem> menuItems;
        public string Name { get { return "DINNER"; } }
        public CafeMenu()
        {
            menuItems = new Dictionary<string, MenuItem>();

            addItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99m);
            addItem("Soup of the day", "Soup of the day, with a side salad", false, 3.69m);
            addItem("Burrito", "A large burrito, with whole pinto beans, salsa, guacamole", true, 4.29m);
            // addItem("Grilled Cheese", "Melted cheese between two toasted slices of bread", false, 2.15m);
            // addItem("Tuna Melt", "Melted cheese, tuna, and two toasted slices of bread", false, 3.15m);

        }

        private void addItem(string name, string desc, bool isVegetarian, decimal price)
        {
            menuItems.Add(name, new MenuItem(name, desc, isVegetarian, price));
        }

        public IEnumerator GetEnumerator()
        {
            return menuItems.Values.GetEnumerator();
        }
    }
}