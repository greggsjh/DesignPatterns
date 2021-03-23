using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class Quackologist : IObserver<IQuackable>
    {
        private IDisposable unsubscriber;
        private IQuackable Duck { get; set; }
        public Quackologist(IObservable<IQuackable> observable)
        {
            Duck = (IQuackable)observable;
            if (observable != null)
                unsubscriber = observable.Subscribe(this);
        }
        public void OnCompleted()
        {
            unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            throw new Exception("An error has occurred.");
        }

        public void OnNext(IQuackable value)
        {
            Duck = value;
            Console.WriteLine(Update());
        }

        public string Update()
        {
            return $"Quackologist: {Duck.GetType().Name} just quacked.";
        }
    }
}