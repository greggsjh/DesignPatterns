using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class GooseAdapter : IQuackable
    {
        IHonkable _goose;
        QuackObservable observable;
        public GooseAdapter(IHonkable goose)
        {
            observable = new QuackObservable(this);
            _goose = goose;
        }

        public string Quack()
        {
            Notify();
            return _goose.Honk();
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