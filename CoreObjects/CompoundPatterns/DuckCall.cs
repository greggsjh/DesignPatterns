using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class DuckCall : IQuackable
    {
        QuackObservable observable;

        public DuckCall()
        {
            observable = new QuackObservable(this);
        }

        public string Quack()
        {
            Notify();
            return "Kwak\n";
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