using System;
using System.Text;
using System.Threading;
using DesignPatterns.TemplateMethodPattern;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("Please enter 1 to test Template Method Pattern.");
                Console.WriteLine("Please enter 2 to test the IComparable Template.");
                Console.WriteLine("Please enter 3 to quit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        TestBeverage();
                        break;
                    case "2":
                        Console.Clear();
                        TestComparable();
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

        private static void TestComparable()
        {
            Duck[] ducks = { new Duck("Daffy", 8),
                             new Duck("Dewey", 2),
                             new Duck("Howard", 7),
                             new Duck("Louie", 2),
                             new Duck("Donald", 10),
                             new Duck("Huey", 2) };

            Console.WriteLine("Before sorting:");
            DisplayDucks(ducks);

            Array.Sort(ducks);

            Console.WriteLine("After sorting");
            DisplayDucks(ducks);
        }

        private static void DisplayDucks(Duck[] ducks)
        {
            foreach (var duck in ducks)
            {
                Console.WriteLine(duck.ToString());
            }
        }

        public static void TestBeverage()
        {
            Console.Clear();
            Tea myTea = new Tea();
            Console.WriteLine(myTea.PrepareRecipe());

            Coffee myCoffee = new Coffee();
            Console.WriteLine(myCoffee.PrepareRecipe());
        }
    }
}
