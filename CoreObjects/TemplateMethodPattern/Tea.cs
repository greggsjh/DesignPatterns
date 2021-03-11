namespace DesignPatterns.CoreObjects.TemplateMethodPattern
{
    public class Tea : CaffeineBeverage
    {
        public override string AddCondiments()
        {
            return "Adding Lemon";
        }

        public override string Brew()
        {
            return "Steeping the tea";
        }
    }
}