using System;

namespace DesignPatterns.DecoratorPattern
{
    public interface IBeverage
    {
        string Description { get; set; }
        decimal Cost();
    }
}