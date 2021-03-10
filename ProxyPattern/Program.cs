using System;
using System.Text;
using System.Threading;
using DesignPatterns.CoreObjects.ProxyPattern;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("Please enter 1 to test the Gumball Machine.");
                Console.WriteLine("Please enter 2 to quit.");

                string input = Console.ReadLine();

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

        private static void GumballMachineTestDrive(string name, int inventory)
        {

            GumballMachine gumballMachine = new GumballMachine(inventory, name);
            GumballMonitor monitor = new GumballMonitor(gumballMachine);

            Console.WriteLine(monitor.Report());
        }
    }
}
