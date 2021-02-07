using System.Collections.Generic;

namespace DesignPatterns.FactoryPattern.FactoryMethod
{
    internal class ChicagoStyleCheesePizza : Pizza
    {
        internal ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";

            if (Toppings == null)
                Toppings = new List<string>();

            Toppings.Add("Shredded Mozzarella Cheese");
        }

        internal override string Cut()
        {
            return "Cutting the pizza into square slices";
        }
    }
}