using System.Text;

namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal class VeggiePizza : Pizza
    {
        private IIngredientFactory IngredientFactory;

        public VeggiePizza(IIngredientFactory ingredientFactory)
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