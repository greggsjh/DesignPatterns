using System;
using DesignPatterns.StatePattern;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);
            for (int i = 0; i < 2; i++)
            {
                GumballMachineTestDrive(gumballMachine);
            }
        }

        private static void GumballMachineTestDrive(GumballMachine gumballMachine)
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
}
