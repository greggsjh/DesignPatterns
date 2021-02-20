using System;

namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class Amplifier
    {
        private const string DEFAULT_NAME = "Default";

        public string Name { get; private set; }

        public Amplifier(string name)
        {
            Name = name;
        }

        internal string On()
        {
            return $"{(string.IsNullOrEmpty(Name) ? DEFAULT_NAME : Name)} Amplifier on";
        }

        internal string SetDvd()
        {
            return $"{(string.IsNullOrEmpty(Name) ? DEFAULT_NAME : Name)} Amplifier setting DVD player to Top-O-Line DVD Player";
        }

        internal string SetSurroundSound()
        {
            return $"{(string.IsNullOrEmpty(Name) ? DEFAULT_NAME : Name)} Amplifier surround sound on (5 speakers, 1 subwoofer)";
        }

        internal string SetVolume(int v)
        {
            return $"{(string.IsNullOrEmpty(Name) ? DEFAULT_NAME : Name)} Amplifier setting volume to {v}";
        }

        internal string Off()
        {
            return $"{(string.IsNullOrEmpty(Name) ? DEFAULT_NAME : Name)} Amplifier off";
        }
    }
}