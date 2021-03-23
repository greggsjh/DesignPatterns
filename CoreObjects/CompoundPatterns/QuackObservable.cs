using System;
using System.Collections.Generic;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class QuackObservable : IObservable<IQuackable>
    {
        private List<IObserver<IQuackable>> Observers { get; set; }
        IQuackable _duck;
        public QuackObservable(IQuackable duck)
        {
            _duck = duck;
            Observers = new List<IObserver<IQuackable>>();
        }
        public IDisposable Subscribe(IObserver<IQuackable> observer)
        {
            if (!Observers.Contains(observer))
                Observers.Add(observer);
            return new Unsubscriber(Observers, observer);
        }

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.OnNext(_duck);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IQuackable>> Observers { get; set; }
            private IObserver<IQuackable> Observer { get; set; }
            public Unsubscriber(List<IObserver<IQuackable>> observers, IObserver<IQuackable> observer)
            {
                Observers = observers;
                Observer = observer;
            }

            public void Dispose()
            {
                if (Observer != null && Observers.Contains(Observer))
                    Observers.Remove(Observer);
            }
        }
    }
}