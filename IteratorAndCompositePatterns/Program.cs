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
            CafeMenu cafeMenu = new CafeMenu();

            Waitress waitress = new Waitress(new IMenu[] { pancakeHouseMenu, dinerMenu, cafeMenu });

            Console.WriteLine(waitress.PrintMenu());
        }
    }
}
