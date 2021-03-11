using System.Text;

namespace DesignPatterns.CoreObjects.FactoryPattern.AbstractFactory
{
    internal class PepperoniPizza : Pizza
    {
        private IIngredientFactory IngredientFactory;

        public PepperoniPizza(IIngredientFactory ingredientFactory)
        {
            IngredientFactory = ingredientFactory;
        }
        internal override string Prepare()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Preparing {Name}");

            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheese = IngredientFactory.CreateCheese();
            Clam = IngredientFactory.CreateClams();

            return sb.ToString();
        }
    }
}