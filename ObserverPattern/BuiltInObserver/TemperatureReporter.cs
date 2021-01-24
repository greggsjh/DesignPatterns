using System;
using System.Collections.Generic;

namespace ObserverPattern.BuiltInObserver
{
    public class TemperatureReporter : IObservable<Temperature>
    {
        private List<IObserver<Temperature>> observers { get; set; }

        public TemperatureReporter()
        {
            observers = new List<IObserver<Temperature>>();
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        public void TemperatureChanged(Temperature temp)
        {
            foreach (var o in observers)
            {
                o.OnNext(temp);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Temperature>> Observers { get; set; }
            private IObserver<Temperature> Observer { get; set; }
            public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
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