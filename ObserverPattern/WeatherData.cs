using System.Collections.Generic;

namespace DesignPatterns.ObserverPattern
{
    public class WeatherData : ISubject
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public List<IObserver> Observers { get; set; }

        public WeatherData()
        {
            Observers = new List<IObserver>();
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(Temperature, Humidity, Pressure);
            }
        }

        public void Subscribe(IObserver observer)
        {
            if (Observers == null)
            {
                Observers = new List<IObserver>();
            }

            Observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            if (Observers != null)
            {
                Observers.Remove(observer);
            }
        }

        public void MeasurementsChanged() => Notify();
        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;

            MeasurementsChanged();
        }
    }
}