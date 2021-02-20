using System;
using System.Text;
using System.Threading;
using DesignPatterns.AdapterAndFacadePattern.AdapterPattern;
using DesignPatterns.AdapterAndFacadePattern.FacadePattern;

namespace AdapterAndFacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("Please enter 1 to test the Adapter Pattern.");
                Console.WriteLine("Please enter 2 to test the Facade Pattern.");
                Console.WriteLine("Please enter 3 to quit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        TestAdapterPattern();
                        break;
                    case "2":
                        Console.Clear();
                        TestFacadePattern();
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
            Console.Clear();
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
    }
}
