using System;

namespace DesignPatterns.CoreObjects.DecoratorPattern
{
    public interface IBeverage
    {
        string Description { get; }
        CoffeeSize Size { get; set; }
        decimal Cost();
    }
}