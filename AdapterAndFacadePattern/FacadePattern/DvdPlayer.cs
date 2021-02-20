using System;

namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class DvdPlayer
    {
        private string _movie;
        private const string DEFAULT_BRAND = "Default";

        public string Brand { get; private set; }

        public DvdPlayer(string brand)
        {
            Brand = brand;
        }

        internal string On()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} DVD Player on";
        }

        internal string Play(string movie)
        {
            _movie = movie;
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} DVD Player playing \"{movie}\"";
        }

        internal string Stop()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} DVD Player stopped \"{_movie}\"";
        }

        internal string Eject()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} DVD Player eject";
        }

        internal string Off()
        {
            return $"{(string.IsNullOrEmpty(Brand) ? DEFAULT_BRAND : Brand)} DVD Player off";
        }
    }
}