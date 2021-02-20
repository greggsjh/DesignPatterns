using System;

namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class Screen
    {
        internal string Down()
        {
            return "Theater Screen going down";
        }

        internal string Up()
        {
            return "Theater Screen going up";
        }
    }
}