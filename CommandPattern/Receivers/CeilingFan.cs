namespace DesignPatterns.CommandPattern
{
    public class CeilingFan
    {
        public const int HIGH = 3;
        public const int MEDIUM = 2;
        public const int LOW = 1;
        public const int OFF = 0;
        public int Speed { get; set; }
        private string Name { get; set; }

        public CeilingFan()
        {

        }
        public CeilingFan(string name)
        {
            Name = name;
            Speed = OFF;
        }
        public void High()
        {
            Speed = HIGH;
        }
        public void Medium()
        {
            Speed = MEDIUM;
        }
        public void Low()
        {
            Speed = LOW;
        }
        public string On()
        {
            string s = GetSpeed();
            return string.IsNullOrEmpty(Name) ? $"Ceiling Fan is On {s}." : $"{Name} Ceiling Fan is On {s}.";
        }

        private string GetSpeed()
        {
            switch (Speed)
            {
                case HIGH:
                    return "High";
                case MEDIUM:
                    return "Medium";
                case LOW:
                    return "Low";
                default:
                    return "Off";
            }
        }

        public string Off()
        {
            Speed = OFF;
            return string.IsNullOrEmpty(Name) ? "Ceiling Fan is Off." : $"{Name} Ceiling Fan is Off.";
        }
    }
}