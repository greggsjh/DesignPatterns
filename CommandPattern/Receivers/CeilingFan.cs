namespace DesignPatterns.CommandPattern
{
    public class CeilingFan
    {
        private string Name { get; set; }

        public CeilingFan()
        {

        }
        public CeilingFan(string name)
        {
            Name = name;
        }
        public string On()
        {
            return string.IsNullOrEmpty(Name) ? "Ceiling Fan is On." : $"{Name} Ceiling Fan is On.";
        }

        public string Off()
        {
            return string.IsNullOrEmpty(Name) ? "Ceiling Fan is Off." : $"{Name} Ceiling Fan is Off.";
        }
    }
}