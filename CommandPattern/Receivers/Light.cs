using System;

namespace DesignPatterns.CommandPattern
{
    public class Light
    {
        private string Name { get; set; }
        public Light()
        {

        }
        public Light(string name)
        {
            Name = name;
        }
        internal string On()
        {
            return string.IsNullOrEmpty(Name) ? "Light is On" : $"{Name} Light is On.";
        }

        internal string Off()
        {
            return string.IsNullOrEmpty(Name) ? "Light is Off" : $"{Name} Light is Off.";
        }
    }
}