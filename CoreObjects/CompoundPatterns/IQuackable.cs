using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public interface IQuackable : IObservable<IQuackable>
    {
        string Quack();
    }
}