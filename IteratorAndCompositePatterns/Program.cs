using System;
using DesignPatterns.IteratorAndCompositePatterns.IteratorPattern;

namespace IteratorAndCompositePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();

            Waitress waitress = new Waitress(dinerMenu, pancakeHouseMenu);

            Console.WriteLine(waitress.PrintMenu());
        }
    }
}
