
namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(string temperature, string humidity, string pressure);
    }
}