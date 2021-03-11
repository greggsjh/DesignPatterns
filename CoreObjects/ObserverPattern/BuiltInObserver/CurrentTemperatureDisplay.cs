using System;
namespace DesignPatterns.CoreObjects.ObserverPattern.BuiltInObserver
{
    public class CurrentTemperatureDisplay : IObserver<Temperature>
    {
        private IDisposable unsubscriber;
        private Temperature Temperature { get; set; }

        public CurrentTemperatureDisplay(IObservable<Temperature> observable)
        {
            if (observable != null)
                unsubscriber = observable.Subscribe(this);
        }

        public void OnCompleted()
        {
            unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            throw new Exception("An error has occurred. The temperature cannot be determined.");
        }

        public void OnNext(Temperature value)
        {
            Temperature = value;
        }

        public string Display()
        {
            return $"Current temperature is {Temperature.Temp}F degrees";
        }
    }
}