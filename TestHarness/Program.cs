using System;
using System.Text;
using System.Threading;
using DesignPatterns.CoreObjects.DecoratorPattern;
using DesignPatterns.CoreObjects.FactoryPattern;
using DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod;
using DesignPatterns.CoreObjects.ObserverPattern;
using DesignPatterns.CoreObjects.ObserverPattern.BuiltInObserver;
using DesignPatterns.CoreObjects.SingletonPattern;
using DesignPatterns.CoreObjects.TemplateMethodPattern;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("Please enter 1 to test the Proxy Pattern.");
                Console.WriteLine("Please enter 2 to test the Decorator Pattern.");
                Console.WriteLine("Please enter 3 to test the Factory Method Pattern.");
                Console.WriteLine("Please enter 4 to test the Observer Pattern.");
                Console.WriteLine("Please enter 5 to test the Singleton Pattern.");
                Console.WriteLine("Please enter 6 to test the State Pattern.");
                Console.WriteLine("Please enter 7 to test the Strategy Pattern.");
                Console.WriteLine("Please enter 8 to test Template Method Pattern.");
                Console.WriteLine("Please enter 9 to test the IComparable Template.");
                Console.WriteLine("Please enter 10 to test the Iterator Pattern.");
                Console.WriteLine("Please enter 11 to test the Composite Pattern.");

                Console.WriteLine("Please enter exit to quit.");

                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Please enter the location");
                        string location = Console.ReadLine();
                        if (string.IsNullOrEmpty(location))
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                        Console.WriteLine("Please enter the count");
                        int count = 0;
                        if (Int32.TryParse(Console.ReadLine(), out count))
                            GumballMachineTestDrive(location, count);
                        else
                            Console.WriteLine("Invalid Input...");
                        break;
                    case "2":
                        TestDecoratorPattern();
                        break;
                    case "3":
                        TestFactoryMethod();
                        break;
                    case "4":
                        TestObserverPattern();
                        break;
                    case "5":
                        TestSingletonPattern();
                        break;
                    case "6":
                        TestStatePattern();
                        break;
                    case "7":
                        TestStrategyPattern();
                        break;
                    case "8":
                        TestTemplateMethodPattern();
                        break;
                    case "9":
                        TestComparable();
                        break;
                    case "10":
                        TestIteratorPattern();
                        break;
                    case "11":
                        TestCompositePattern();
                        break;
                    case "exit":
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
            Console.Clear();
        }

        private static void TestIteratorPattern()
        {
            DesignPatterns.CoreObjects.IteratorPattern.PancakeHouseMenu pancakeHouseMenu = new DesignPatterns.CoreObjects.IteratorPattern.PancakeHouseMenu();
            DesignPatterns.CoreObjects.IteratorPattern.DinerMenu dinerMenu = new DesignPatterns.CoreObjects.IteratorPattern.DinerMenu();
            DesignPatterns.CoreObjects.IteratorPattern.CafeMenu cafeMenu = new DesignPatterns.CoreObjects.IteratorPattern.CafeMenu();

            DesignPatterns.CoreObjects.IteratorPattern.Waitress waitress = new DesignPatterns.CoreObjects.IteratorPattern.Waitress(
                new DesignPatterns.CoreObjects.IteratorPattern.IMenu[]
                {
                    pancakeHouseMenu,
                    dinerMenu,
                    cafeMenu
                });

            Console.WriteLine(waitress.PrintMenu());
        }

        private static void TestCompositePattern()
        {
            DesignPatterns.CoreObjects.CompositePattern.MenuComponent pancakeHouseMenu =
                new DesignPatterns.CoreObjects.CompositePattern.Menu("PANCAKE HOUSE MENU", "Breakfast");

            DesignPatterns.CoreObjects.CompositePattern.MenuComponent dinerMenu =
                new DesignPatterns.CoreObjects.CompositePattern.Menu("DINER MENU", "Lunch");

            DesignPatterns.CoreObjects.CompositePattern.MenuComponent cafeMenu =
                new DesignPatterns.CoreObjects.CompositePattern.Menu("CAFE MENU", "Dinner");

            DesignPatterns.CoreObjects.CompositePattern.MenuComponent dessertMenu =
                new DesignPatterns.CoreObjects.CompositePattern.Menu("DESSERT MENU", "Dessert of course!");

            DesignPatterns.CoreObjects.CompositePattern.MenuComponent allMenus =
                new DesignPatterns.CoreObjects.CompositePattern.Menu("ALL MENUS", "All menus combined");

            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);

            pancakeHouseMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99m));
            pancakeHouseMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99m));
            pancakeHouseMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49m));
            pancakeHouseMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59m));

            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat)", true, 2.99m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Grilled Cheese", "Melted cheese between two toasted slices of bread", false, 2.15m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Tuna Melt", "Melted cheese, tuna, and two toasted slices of bread", false, 3.15m));

            cafeMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99m));
            cafeMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Soup of the day", "Soup of the day, with a side salad", false, 3.69m));
            cafeMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Burrito", "A large burrito, with whole pinto beans, salsa, guacamole", true, 4.29m));

            dinerMenu.Add(dessertMenu);

            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Apple Pie", "Apple pie with a flakey crust, topped with vanilla icecream", true, 1.59m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Cheesecake", "Creamy New York cheesecake, with a chocolate graham crust", true, 1.99m));
            dinerMenu.Add(new DesignPatterns.CoreObjects.CompositePattern.MenuItem("Sorbet", "A scoop of raspberry and a scooop of lime", true, 1.89m));

            DesignPatterns.CoreObjects.CompositePattern.Waitress waitress = new DesignPatterns.CoreObjects.CompositePattern.Waitress(allMenus);

            Console.WriteLine(waitress.PrintMenu());
        }

        private static void TestComparable()
        {
            DesignPatterns.TemplateMethodPattern.Duck[] ducks = { new DesignPatterns.TemplateMethodPattern.Duck("Daffy", 8),
                             new DesignPatterns.TemplateMethodPattern.Duck("Dewey", 2),
                             new DesignPatterns.TemplateMethodPattern.Duck("Howard", 7),
                             new DesignPatterns.TemplateMethodPattern.Duck("Louie", 2),
                             new DesignPatterns.TemplateMethodPattern.Duck("Donald", 10),
                             new DesignPatterns.TemplateMethodPattern.Duck("Huey", 2) };

            Console.WriteLine("Before sorting:");
            DisplayDucks(ducks);

            Array.Sort(ducks);

            Console.WriteLine("After sorting");
            DisplayDucks(ducks);
        }

        private static void DisplayDucks(DesignPatterns.TemplateMethodPattern.Duck[] ducks)
        {
            foreach (var duck in ducks)
            {
                Console.WriteLine(duck.ToString());
            }
        }

        public static void TestTemplateMethodPattern()
        {
            Console.Clear();
            Tea myTea = new Tea();
            Console.WriteLine(myTea.PrepareRecipe());

            Coffee myCoffee = new Coffee();
            Console.WriteLine(myCoffee.PrepareRecipe());
        }
        private static void TestStrategyPattern()
        {
            DesignPatterns.CoreObjects.StrategyPattern.Mallard mallard = new DesignPatterns.CoreObjects.StrategyPattern.Mallard();
            mallard.Fly();
            mallard.Quack();
            Console.ReadLine();

            DesignPatterns.CoreObjects.StrategyPattern.Duck model = new DesignPatterns.CoreObjects.StrategyPattern.ModelDuck();
            model.Fly();
            (model as DesignPatterns.CoreObjects.StrategyPattern.ModelDuck).FlyBehavior = new DesignPatterns.CoreObjects.StrategyPattern.FlyRocketPowered();
            model.Fly();
        }

        private static void TestStatePattern()
        {
            DesignPatterns.CoreObjects.StatePattern.GumballMachine gumballMachine = new DesignPatterns.CoreObjects.StatePattern.GumballMachine(5);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(gumballMachine.ToString());

                Console.WriteLine(gumballMachine.InsertQuarter());
                Console.WriteLine(gumballMachine.TurnCrank());

                Console.WriteLine(gumballMachine.ToString());

                Console.WriteLine(gumballMachine.InsertQuarter());
                Console.WriteLine(gumballMachine.TurnCrank());

                Console.WriteLine(gumballMachine.Refill(5));

                Console.WriteLine(gumballMachine.InsertQuarter());
                Console.WriteLine(gumballMachine.TurnCrank());
            }
        }
        private static void TestSingletonPattern()
        {
            ChocolateBoiler chocolateBoiler = ChocolateBoiler.Instance;

            Console.WriteLine(chocolateBoiler.Fill());
            Console.WriteLine(chocolateBoiler.Boil());
            Console.WriteLine(chocolateBoiler.Drain());
        }

        private static void TestObserverPattern()
        {
            WeatherData weatherData = new WeatherData();
            TemperatureReporter temperatureReporter = new TemperatureReporter();

            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);
            CurrentTemperatureDisplay currentTemperatureDisplay = new CurrentTemperatureDisplay(temperatureReporter);

            Temperature t = new Temperature { Temp = 80 };
            temperatureReporter.TemperatureChanged(t);

            t.Temp = 82;
            temperatureReporter.TemperatureChanged(t);
            Console.WriteLine(currentTemperatureDisplay.Display());

            t.Temp = 78;
            temperatureReporter.TemperatureChanged(t);
            Console.WriteLine(currentTemperatureDisplay.Display());

            weatherData.SetMeasurements(80, 65, 30.4);
            weatherData.SetMeasurements(82, 70, 29.2);
            weatherData.SetMeasurements(78, 90, 29.2);

            Console.WriteLine(currentConditionsDisplay.Display());
            Console.WriteLine(statisticsDisplay.Display());
            Console.WriteLine(forecastDisplay.Display());
            Console.WriteLine(heatIndexDisplay.Display());
        }

        private static void TestFactoryMethod()
        {
            PizzaStore nyPizzaStore = new NYPizzaStore();
            PizzaStore chicagoPizzaStore = new ChicagoPizzaStore();

            string message;
            Pizza pizza = nyPizzaStore.OrderPizza(PizzaType.Cheese, out message);
            Console.Write(message);
            Console.WriteLine($"Ethan ordered a {pizza.Name} \n");

            string messageOne;
            Pizza pizzaOne = chicagoPizzaStore.OrderPizza(PizzaType.Cheese, out messageOne);
            Console.Write(messageOne);
            Console.WriteLine($"Joel ordered a {pizzaOne.Name} \n");
        }

        private static void TestDecoratorPattern()
        {
            IBeverage beverage = new Espresso(CoffeeSize.Tall);
            Console.WriteLine("{0} $ {1}", beverage.Description, beverage.Cost());

            IBeverage beverage1 = new DarkRoast(CoffeeSize.Tall);
            beverage1 = new Mocha(beverage1);
            beverage1 = new Mocha(beverage1);
            beverage1 = new Whip(beverage1);
            Console.WriteLine($"{beverage1.Description} $ {beverage1.Cost()}");

            IBeverage beverage2 = new HouseBlend(CoffeeSize.Tall);
            beverage2 = new Soy(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.Description} $ {beverage2.Cost()}");
        }

        private static void GumballMachineTestDrive(string name, int inventory)
        {

            DesignPatterns.CoreObjects.ProxyPattern.GumballMachine gumballMachine = new DesignPatterns.CoreObjects.ProxyPattern.GumballMachine(inventory, name);
            DesignPatterns.CoreObjects.ProxyPattern.GumballMonitor monitor = new DesignPatterns.CoreObjects.ProxyPattern.GumballMonitor(gumballMachine);

            Console.WriteLine(monitor.Report());
        }
    }
}
