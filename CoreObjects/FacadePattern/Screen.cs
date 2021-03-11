using System;

namespace DesignPatterns.CoreObjects.FacadePattern
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