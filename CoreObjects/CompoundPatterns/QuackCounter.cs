using System;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class QuackCounter : IQuackable
    {
        IQuackable _bird;
        QuackObservable observable;
        public static int NumberOfQuacks { get; internal set; }

        public QuackCounter(IQuackable bird)
        {
            observable = new QuackObservable(this);
            _bird = bird;
        }

        public string Quack()
        {
            Notify();
            string quack = _bird.Quack();
            NumberOfQuacks++;
            return quack;
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