using System.Text;

namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal class CheezePizza : Pizza
    {
        public IIngredientFactory IngredientFactory { get; set; }

        public CheezePizza(IIngredientFactory factory)
        {
            IngredientFactory = factory;
        }

        internal override string Prepare()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Preparing {Name}");
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheese = IngredientFactory.CreateCheese();

            return sb.ToString();
        }
    }
}