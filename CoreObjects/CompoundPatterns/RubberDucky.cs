using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class RubberDucky : IQuackable
    {
        QuackObservable observable;
        public RubberDucky()
        {
            observable = new QuackObservable(this);
        }
        public string Quack()
        {
            Notify();
            return "Squeak\n";
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