using System;

namespace DesignPatterns.DecoratorPattern
{
    public interface IBeverage
    {
        string Description { get; }
        CoffeeSize Size { get; set; }
        decimal Cost();
    }
}