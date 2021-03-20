using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class CountingDuckFactory : IAbstractDuckFactory
    {
        public IQuackable CreateDuckCall()
        {
            return new QuackCounter(new DuckCall());
        }

        public IQuackable CreateGooseAdapter()
        {
            throw new InvalidOperationException();
        }

        public IQuackable CreateRedheadDuck()
        {
            return new QuackCounter(new RedheadDuck());
        }

        public IQuackable CreateRubberDuck()
        {
            return new QuackCounter(new RubberDucky());
        }

        public IQuackable CreateWildMallard()
        {
            return new QuackCounter(new WildMallard());
        }
    }
}