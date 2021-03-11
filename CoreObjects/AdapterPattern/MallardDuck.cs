namespace DesignPatterns.CoreObjects.AdapterPattern
{
    public class MallardDuck : IDuck
    {
        public string Fly()
        {
            return "I'm flying";
        }

        public string Quack()
        {
            return "Quack";
        }
    }
}