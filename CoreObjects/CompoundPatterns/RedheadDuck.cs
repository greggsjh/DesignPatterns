using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class RedheadDuck : IQuackable
    {
        QuackObservable observable;
        public RedheadDuck()
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