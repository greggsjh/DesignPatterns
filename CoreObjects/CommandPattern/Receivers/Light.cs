using System;

namespace DesignPatterns.CoreObjects.CommandPattern
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
        public string On()
        {
            return string.IsNullOrEmpty(Name) ? "Light is On" : $"{Name} Light is On.";
        }

        public string Off()
        {
            return string.IsNullOrEmpty(Name) ? "Light is Off" : $"{Name} Light is Off.";
        }
    }
}