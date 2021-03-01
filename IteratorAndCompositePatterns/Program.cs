using System;
using System.Text;
using System.Threading;

namespace IteratorAndCompositePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("Please enter 1 to test the Iterator Pattern.");
                Console.WriteLine("Please enter 2 to test the Composite Template.");
                Console.WriteLine("Please enter 3 to quit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        TestIterator();
                        break;
                    case "2":
                        Console.Clear();
                        TestComposite();
                        break;
                    case "3":
                        Console.Clear();
                        retry = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input...");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Quitting");
            Console.WriteLine(sb.ToString());
            Thread.Sleep(1250);

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                sb.Append(".");
                Console.WriteLine(sb.ToString());
                Thread.Sleep(500);
            }
        }

        private static void TestComposite()
        {
            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuComponent pancakeHouseMenu =
                new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Menu("PANCAKE HOUSE MENU", "Breakfast");

            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuComponent dinerMenu =
                new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Menu("DINER MENU", "Lunch");

            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuComponent cafeMenu =
                new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Menu("CAFE MENU", "Dinner");

            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuComponent dessertMenu =
                new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Menu("DESSERT MENU", "Dessert of course!");

            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuComponent allMenus =
                new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Menu("ALL MENUS", "All menus combined");

            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);

            pancakeHouseMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99m));
            pancakeHouseMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99m));
            pancakeHouseMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49m));
            pancakeHouseMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59m));

            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat)", true, 2.99m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Grilled Cheese", "Melted cheese between two toasted slices of bread", false, 2.15m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Tuna Melt", "Melted cheese, tuna, and two toasted slices of bread", false, 3.15m));

            cafeMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99m));
            cafeMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Soup of the day", "Soup of the day, with a side salad", false, 3.69m));
            cafeMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Burrito", "A large burrito, with whole pinto beans, salsa, guacamole", true, 4.29m));

            dinerMenu.Add(dessertMenu);

            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Apple Pie", "Apple pie with a flakey crust, topped with vanilla icecream", true, 1.59m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Cheesecake", "Creamy New York cheesecake, with a chocolate graham crust", true, 1.99m));
            dinerMenu.Add(new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.MenuItem("Sorbet", "A scoop of raspberry and a scooop of lime", true, 1.89m));

            DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Waitress waitress = new DesignPatterns.IteratorAndCompositePatterns.CompositePattern.Waitress(allMenus);

            Console.WriteLine(waitress.PrintMenu());
        }

        private static void TestIterator()
        {
            DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.PancakeHouseMenu pancakeHouseMenu = new DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.PancakeHouseMenu();
            DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.DinerMenu dinerMenu = new DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.DinerMenu();
            DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.CafeMenu cafeMenu = new DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.CafeMenu();

            DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.Waitress waitress = new DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.Waitress(
                new DesignPatterns.IteratorAndCompositePatterns.IteratorPattern.IMenu[]
                {
                    pancakeHouseMenu,
                    dinerMenu,
                    cafeMenu
                });

            Console.WriteLine(waitress.PrintMenu());
        }
    }
}
