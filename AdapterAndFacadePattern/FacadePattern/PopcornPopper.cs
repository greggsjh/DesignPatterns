using System;

namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class PopcornPopper
    {
        internal string On()
        {
            return "Popcorn Popper on";
        }

        internal string Pop()
        {
            return "Popcorn Popper popping popcorn!";
        }

        internal string Off()
        {
            return "Popcorn Popper off";
        }
    }
}