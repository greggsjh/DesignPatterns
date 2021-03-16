using System;
using DesignPatterns.CoreObjects.ProxyPattern;

namespace DesignPatterns.CoreObjects.Helpers
{
    public static class Helper
    {
        public static IState StateFactory(string name, GumballMachine gumballMachine)
        {
            switch (name)
            {
                case "HasQuarterState":
                    return new HasQuarterState(gumballMachine);
                case "NoQuarterState":
                    return new NoQuarterState(gumballMachine);
                case "SoldOutState":
                    return new SoldOutState(gumballMachine);
                case "SoldState":
                    return new SoldState(gumballMachine);
                case "WinnerState":
                    return new WinnerState(gumballMachine);
                default:
                    throw new Exception($"An error has occurred.");
            }
        }
    }
}