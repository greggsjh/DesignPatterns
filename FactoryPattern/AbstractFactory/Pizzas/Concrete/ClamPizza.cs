using System.Text;

namespace DesignPatterns.FactoryPattern.AbstractFactory
{
    internal class ClamPizza : Pizza
    {
        public IIngredientFactory IngredientFactory { get; set; }
        public ClamPizza(IIngredientFactory factory)
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
            Clam = IngredientFactory.CreateClams();

            return sb.ToString();
        }
    }
}