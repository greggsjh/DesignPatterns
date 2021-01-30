using System.Collections.Generic;

namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal class NYStyleCheesePizza : Pizza
    {
        internal NYStyleCheesePizza()
        {
            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";

            if (Toppings == null)
                Toppings = new List<string>();

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}