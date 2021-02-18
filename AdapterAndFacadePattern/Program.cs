using System;
using System.Text;
using DesignPatterns.AdapterAndFacadePattern.AdapterPattern;

namespace AdapterAndFacadePattern
{
    class Program
    {
        static void Main(string[] args)
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
