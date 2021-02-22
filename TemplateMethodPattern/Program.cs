using System;
using DesignPatterns.TemplateMethodPattern;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Tea myTea = new Tea();
            Console.WriteLine(myTea.PrepareRecipe());

            Coffee myCoffee = new Coffee();
            Console.WriteLine(myCoffee.PrepareRecipe());
        }
    }
}
