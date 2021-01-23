using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern
{
    public class StatisticsDisplay : IDisplay, IObserver
    {
        public List<double> Humidities { get; set; }
        public List<double> Temperatures { get; set; }
        public List<double> Pressures { get; set; }
        public ISubject Subject { get; set; }

        public StatisticsDisplay(ISubject subject)
        {
            Humidities = new List<double>();
            Temperatures = new List<double>();
            Pressures = new List<double>();

            Subject = subject;
            Subject.Subscribe(this);
        }
        public string Display()
        {
            return $"Avg/Max/Min Temperature: {Math.Round((Temperatures.Sum(t => t) / Temperatures.Count), 2)}F/{Temperatures.Max()}/{Temperatures.Min()}";
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Humidities.Add(humidity);
            Temperatures.Add(temperature);
            Pressures.Add(pressure);
        }
    }
}