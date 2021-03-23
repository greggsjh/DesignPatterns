using System;
using System.Text;
using System.Threading;
using DesignPatterns.CoreObjects.AdapterPattern;
using DesignPatterns.CoreObjects.CommandPattern;
using DesignPatterns.CoreObjects.CompoundPatterns;
using DesignPatterns.CoreObjects.DecoratorPattern;
using DesignPatterns.CoreObjects.FacadePattern;
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
        //private static HttpClient _client = new HttpClient();
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
                Console.WriteLine("Please enter 12 to test the Adapter Pattern.");
                Console.WriteLine("Please enter 13 to test the Facade Pattern.");
                Console.WriteLine("Please enter 14 to test the Command Pattern.");
                Console.WriteLine("Please enter 15 to test the Remote Proxy Pattern.");
                Console.WriteLine("Please enter 16 to test the Pattern of Patterns.");

                Console.WriteLine("Please type 'exit' to quit.");

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
                    case "12":
                        TestAdapterPattern();
                        break;
                    case "13":
                        TestFacadePattern();
                        break;
                    case "14":
                        TestCommandPattern();
                        break;
                    case "15":
                        TestRemoteProxyPattern();
                        break;
                    case "16":
                        TestPatternOfPatterns();
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

        private static void TestPatternOfPatterns()
        {
            IAbstractDuckFactory duckFactory = new CountingDuckFactory();
            IAbstractDuckFactory nonCountingDuckFactory = new AbstractDuckFactory();

            IQuackable mallardDuck = duckFactory.CreateWildMallard();
            IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable gooseAdapter = nonCountingDuckFactory.CreateGooseAdapter();

            Console.WriteLine("\nDuck Simulator: With Composite - Flocks");

            Flock flockOfDucks = new Flock();
            flockOfDucks.Quackers.Add(redheadDuck);
            flockOfDucks.Quackers.Add(duckCall);
            flockOfDucks.Quackers.Add(rubberDuck);
            flockOfDucks.Quackers.Add(gooseAdapter);

            Flock flockOfMallards = new Flock();
            IQuackable mallardOne = duckFactory.CreateWildMallard();
            IQuackable mallardTwo = duckFactory.CreateWildMallard();
            IQuackable mallardThree = duckFactory.CreateWildMallard();
            IQuackable mallardFour = duckFactory.CreateWildMallard();

            flockOfMallards.Quackers.Add(mallardOne);
            flockOfMallards.Quackers.Add(mallardTwo);
            flockOfMallards.Quackers.Add(mallardThree);
            flockOfMallards.Quackers.Add(mallardFour);

            flockOfDucks.Quackers.Add(flockOfMallards);

            Console.WriteLine("\nDuck Simulator: With Observer");

            Quackologist quackologist = new Quackologist(flockOfDucks);
            flockOfDucks.Subscribe(quackologist);

            Console.WriteLine("Duck Simulator: Whole Flock Simulation");
            SimulateDuck(flockOfDucks);

            Console.WriteLine("Duck Simulator: Mallard Flock Simulation");
            SimulateDuck(flockOfMallards);

            Console.WriteLine($"The ducks quacked {QuackCounter.NumberOfQuacks} times");
        }

        private static void SimulateDuck(IQuackable rubberDuck)
        {
            Console.WriteLine(rubberDuck.Quack());
        }

        private static void TestCommandPattern()
        {
            try
            {
                Console.WriteLine(ProcessSimpleRemote());
                Console.WriteLine(ProcessRemoteControl());
                Console.WriteLine(ProcessRemoteControlWithUndo());
                Console.WriteLine(ProcessRemoteControlWithUndoComplex());
                Console.WriteLine(ProcessMacroCommand());
                Console.WriteLine(ProcessLambdaCommand());

            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Undo is not implemented for this command. Message {ex.Message}");
            }
        }

        private static string ProcessLambdaCommand()
        {
            StringBuilder sb = new StringBuilder();
            LambdaRemoteControl remoteControl = new LambdaRemoteControl();

            Light livingRoomLight = new Light("Living Room");
            remoteControl.OnCommands[0] = () => { return livingRoomLight.On(); };
            remoteControl.OffCommands[0] = () => { return livingRoomLight.Off(); };

            sb.AppendLine(remoteControl.ToString());
            sb.AppendLine(remoteControl.OnButtonWasPushed(0));
            sb.AppendLine(remoteControl.OffButtonWasPushed(0));

            return sb.ToString();
        }

        private static string ProcessMacroCommand()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControl remoteControl = new RemoteControl();

            Light light = new Light("Living Room");
            Stereo stereo = new Stereo();

            LightOnCommand lightOn = new LightOnCommand(light);
            StereoOnWithCDCommand stereoOn = new StereoOnWithCDCommand(stereo);

            LightOffCommand lightOff = new LightOffCommand(light);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);

            ICommand[] partyOn = { lightOn, stereoOn };
            ICommand[] partyOff = { lightOff, stereoOff };

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.OnCommands[0] = partyOnMacro;
            remoteControl.OffCommands[0] = partyOffMacro;

            sb.AppendLine(remoteControl.ToString());
            sb.AppendLine("--- Pushing Macro On ---");
            sb.AppendLine(remoteControl.OnButtonWasPushed(0));
            sb.AppendLine("--- Pushing Macro Off ---");
            sb.AppendLine(remoteControl.OffButtonWasPushed(0));

            return sb.ToString();
        }

        private static string ProcessRemoteControlWithUndoComplex()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControlWithUndo remoteControlUndo = new RemoteControlWithUndo();
            CeilingFan ceilingFan1 = new CeilingFan("Living Room");

            remoteControlUndo.OnCommands[0] = new CeilingFanMediumCommand(ceilingFan1);
            remoteControlUndo.OffCommands[0] = new CeilingFanOffCommand(ceilingFan1);

            remoteControlUndo.OnCommands[1] = new CeilingFanHighCommand(ceilingFan1);
            remoteControlUndo.OffCommands[1] = new CeilingFanOffCommand(ceilingFan1);

            sb.AppendLine(remoteControlUndo.OnButtonWasPushed(0));
            sb.AppendLine(remoteControlUndo.OffButtonWasPushed(0));
            sb.AppendLine(remoteControlUndo.ToString());
            sb.AppendLine(remoteControlUndo.UndoButtonWasPushed());

            sb.AppendLine(remoteControlUndo.OnButtonWasPushed(1));
            sb.AppendLine(remoteControlUndo.ToString());
            sb.AppendLine(remoteControlUndo.UndoButtonWasPushed());

            return sb.ToString();
        }

        private static string ProcessRemoteControlWithUndo()
        {
            StringBuilder sb = new StringBuilder();

            RemoteControlWithUndo remoteControlWithUndo = new RemoteControlWithUndo();

            Light livingRoomLight = new Light("Living Room");

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            remoteControlWithUndo.OnCommands[0] = livingRoomLightOn;
            remoteControlWithUndo.OffCommands[0] = livingRoomLightOff;

            sb.AppendLine(remoteControlWithUndo.OnButtonWasPushed(0));
            sb.AppendLine(remoteControlWithUndo.OffButtonWasPushed(0));
            sb.AppendLine(remoteControlWithUndo.ToString());
            sb.AppendLine(remoteControlWithUndo.UndoButtonWasPushed());
            sb.AppendLine(remoteControlWithUndo.OffButtonWasPushed(0));
            sb.AppendLine(remoteControlWithUndo.OnButtonWasPushed(0));
            sb.AppendLine(remoteControlWithUndo.ToString());
            sb.AppendLine(remoteControlWithUndo.UndoButtonWasPushed());

            return sb.ToString();
        }

        private static string ProcessRemoteControl()
        {
            RemoteControl remoteControl = new RemoteControl();

            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            CeilingFan ceilingFan = new CeilingFan("Living Room");
            GarageDoor garage = new GarageDoor();
            Stereo stereo = new Stereo();

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

            CeilingFanOnCommand ceilingFanOnCommand = new CeilingFanOnCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOffCommand = new CeilingFanOffCommand(ceilingFan);

            GarageDoorOpenCommand garageDoorOpen = new GarageDoorOpenCommand(garage);
            GarageDoorCloseCommand garageDoorClose = new GarageDoorCloseCommand(garage);

            StereoOnWithCDCommand stereoOnWithCDCommand = new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOffCommand = new StereoOffCommand(stereo);

            remoteControl.OnCommands[0] = livingRoomLightOn;
            remoteControl.OnCommands[1] = kitchenLightOn;
            remoteControl.OnCommands[2] = ceilingFanOnCommand;
            remoteControl.OnCommands[3] = stereoOnWithCDCommand;

            remoteControl.OffCommands[0] = livingRoomLightOff;
            remoteControl.OffCommands[1] = kitchenLightOff;
            remoteControl.OffCommands[2] = ceilingFanOffCommand;
            remoteControl.OffCommands[3] = stereoOffCommand;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(remoteControl.ToString());

            sb.AppendLine(remoteControl.OnButtonWasPushed(0));
            sb.AppendLine(remoteControl.OffButtonWasPushed(0));
            sb.AppendLine(remoteControl.OnButtonWasPushed(1));
            sb.AppendLine(remoteControl.OffButtonWasPushed(1));
            sb.AppendLine(remoteControl.OnButtonWasPushed(2));
            sb.AppendLine(remoteControl.OffButtonWasPushed(2));
            sb.AppendLine(remoteControl.OnButtonWasPushed(3));
            sb.AppendLine(remoteControl.OffButtonWasPushed(3));

            return sb.ToString();
        }

        private static string ProcessSimpleRemote()
        {
            StringBuilder sb = new StringBuilder();
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);
            GarageDoor garageDoor = new GarageDoor();
            GarageDoorOpenCommand garageDoorOpenCommand = new GarageDoorOpenCommand(garageDoor);

            remote.Slot = lightOn;
            sb.AppendLine(remote.ButtonWasPressed());
            remote.Slot = garageDoorOpenCommand;
            sb.AppendLine(remote.ButtonWasPressed());

            return sb.ToString();
        }
        private static void TestFacadePattern()
        {
            string brand = "Top-O-Line";
            Amplifier a = new Amplifier(brand);
            Tuner t = new Tuner();
            DvdPlayer d = new DvdPlayer(brand);
            CdPlayer c = new CdPlayer(brand);
            Projector p = new Projector(brand);
            Screen s = new Screen();
            TheaterLights l = new TheaterLights();
            PopcornPopper pp = new PopcornPopper();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(a, t, d, c, p, s, l, pp);

            Console.WriteLine(homeTheater.WatchMovie("Black Panther"));
            Console.WriteLine(homeTheater.EndMovie());
        }

        private static void TestAdapterPattern()
        {
            MallardDuck duck = new MallardDuck();

            WildTurkey turkey = new WildTurkey();
            IDuck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The Turkey says...");
            Console.WriteLine(turkey.Gobble());
            Console.WriteLine(turkey.Fly());

            Console.WriteLine();

            Console.WriteLine("The Duck says...");
            Console.WriteLine(TestDuck(duck));

            Console.WriteLine("The TurkeyAdapter says ...");
            Console.WriteLine(TestDuck(turkeyAdapter));
        }

        private static string TestDuck(IDuck duck)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(duck.Quack());
            sb.AppendLine(duck.Fly());

            return sb.ToString();
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

        private static void TestRemoteProxyPattern()
        {
            string[] locations = new string[] { "SantaFe", "Boulder", "Seattle", "Atlanta", "Columbia" };
            DesignPatterns.CoreObjects.ProxyPattern.GumballMonitor[] monitors = new DesignPatterns.CoreObjects.ProxyPattern.GumballMonitor[locations.Length];
            Random randomNum = new Random();
            for (int i = 0; i < locations.Length; i++)
            {
                monitors[i] = new DesignPatterns.CoreObjects.ProxyPattern.GumballMonitor(new DesignPatterns.CoreObjects.ProxyPattern.GumballMachineProxy(randomNum.Next(25), locations[i]));

                Console.WriteLine(monitors[i].Report());
                Console.WriteLine();
            }
        }
    }
}