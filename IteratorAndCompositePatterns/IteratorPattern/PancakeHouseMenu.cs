using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public class PancakeHouseMenu : IEnumerable
    {
        public List<MenuItem> MenuItems { get; set; }

        public PancakeHouseMenu()
        {
            MenuItems = new List<MenuItem>();

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
            for (int i = 0; i < MenuItems.Count; i++)
            {
                yield return MenuItems[i];
            }
        }
    }
}