using System;

namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class Projector
    {
        private const string DEFAULT_BRAND = "Default";
        public Projector(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; private set; }

        internal string On()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} Projector on";
        }

        internal string WideScreenMode()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} Projector in widescreen mode (16X9 aspect ratio)";
        }

        internal string Off()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} Projector off";
        }
    }
}