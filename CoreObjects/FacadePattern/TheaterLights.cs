using System;

namespace DesignPatterns.CoreObjects.FacadePattern
{
    public class TheaterLights
    {
        internal string Dim(int v)
        {
            return $"Theater Ceiling Lights dimming to {v}%";
        }

        internal string On()
        {
            return $"Theater Ceiling Lights on";
        }
    }
}