using System;
using System.Text;

namespace DesignPatterns.TemplateMethodPattern
{
    public abstract class CaffeineBeverage
    {
        public string PrepareRecipe()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(BoilWater());
            sb.AppendLine(Brew());
            sb.AppendLine(PourInCup());
            sb.AppendLine(AddCondiments());

            return sb.ToString();
        }

        public abstract string Brew();
        public abstract string AddCondiments();
        private string BoilWater()
        {
            return "Boiling water";
        }

        private string PourInCup()
        {
            return "Pouring into cup";
        }

    }
}