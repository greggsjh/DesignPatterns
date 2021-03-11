namespace DesignPatterns.CoreObjects.AdapterPattern
{
    public class WildTurkey : ITurkey
    {
        public string Fly()
        {
            return "I'm flying a short distance.";
        }

        public string Gobble()
        {
            return "Gobble gobble.";
        }
    }
}