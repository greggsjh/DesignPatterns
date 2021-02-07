using System;

namespace DesignPatterns.FactoryPattern.SimplePizzaFactory
{
    public abstract class Pizza
    {
        internal virtual void Prepare()
        {
            throw new NotImplementedException();
        }

        internal virtual void Bake()
        {
            throw new NotImplementedException();
        }

        internal virtual void Cut()
        {
            throw new NotImplementedException();
        }

        internal virtual void Box()
        {
            throw new NotImplementedException();
        }
    }
}