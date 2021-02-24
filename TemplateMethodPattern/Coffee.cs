using System;

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
        public override bool CustomerWantsCondiments()
        {
            string answer = GetUserInput();
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            return false;
        }

        private string GetUserInput()
        {
            string answer = string.Empty;
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)?");

            try
            {
                answer = Console.ReadLine();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex}");
            }

            if (string.IsNullOrEmpty(answer))
            {
                return "no";
            }
            return answer;
        }
    }
}