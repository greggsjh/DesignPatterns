namespace DesignPatterns.CoreObjects.ObserverPattern
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void Notify();
    }
}