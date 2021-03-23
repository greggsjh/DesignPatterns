using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CoreObjects.CompoundPatterns
{
    public class Flock : IQuackable
    {
        public List<IQuackable> Quackers { get; set; }
        QuackObservable observable;
        public Flock()
        {
            observable = new QuackObservable(this);
            Quackers = new List<IQuackable>();
        }

        public string Quack()
        {
            Notify();
            StringBuilder sb = new StringBuilder();
            foreach (var item in Quackers)
            {
                sb.AppendLine(item.Quack());
            }
            return sb.ToString();
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