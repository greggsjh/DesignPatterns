using System;
using System.Collections;

namespace DesignPatterns.CoreObjects.IteratorPattern
{
    public class DinerMenu : IMenu
    {
        private const int MAX_ITEMS = 6;
        private int numberOfItems = 0;
        private MenuItem[] menuItems;
        public string Name { get { return "LUNCH"; } }

        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            addItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat)", true, 2.99m);
            addItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99m);
            addItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29m);
            addItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05m);
            addItem("Grilled Cheese", "Melted cheese between two toasted slices of bread", false, 2.15m);
            addItem("Tuna Melt", "Melted cheese, tuna, and two toasted slices of bread", false, 3.15m);
        }

        private void addItem(string name, string description, bool isVegetarian, decimal price)
        {
            MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);
            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full! Can't add item to menu");
            }
            else
            {
                menuItems[numberOfItems] = menuItem;
                numberOfItems++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in menuItems)
            {
                yield return item;
            }
        }
    }
}