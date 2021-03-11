using System.Collections.Generic;

namespace DesignPatterns.CoreObjects.FactoryPattern.FactoryMethod
{
    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";

            if (Toppings == null)
                Toppings = new List<string>();

            Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override string Cut()
        {
            return "Cutting the pizza into square slices";
        }
    }
}