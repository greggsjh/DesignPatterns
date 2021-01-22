namespace ObserverPattern
{
    public interface ISubject
    {
        void Subscribe();
        void UnSubscribe();
        void Notify();
    }
}