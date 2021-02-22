namespace DesignPatterns.TemplateMethodPattern
{
    public class Coffee : CaffeineBeverage
    {
        public override string AddCondiments()
        {
            return "Adding Sugar and Milk";
        }

        public override string Brew()
        {
            return "Dripping Coffee through filter";
        }
    }
}