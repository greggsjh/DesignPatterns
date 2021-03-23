using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class WildMallard : IQuackable
    {
        QuackObservable observable;
        public WildMallard()
        {
            observable = new QuackObservable(this);
        }
        public string Quack()
        {
            Notify();
            return "Quack\n";
        }

        public IDisposable Subscribe(IObserver<IQuackable> observer)
        {
            return observable.Subscribe(observer);
        }

        public void Notify()
        {
            observable.Notify();
        }
    }
}