using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern
{
    public class HeatIndexDisplay : IDisplay, IObserver
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public ISubject Subject { get; set; }

        public HeatIndexDisplay(ISubject subject)
        {
            Subject = subject;
            Subject.Subscribe(this);
        }
        public string Display()
        {
            return $"Heat index is {Math.Round(ComputeHeatIndex(Temperature, Humidity), 5)}";
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Humidity = humidity;
            Temperature = temperature;
            Pressure = pressure;
        }

        private double ComputeHeatIndex(double t, double rh)
        {
            double index = (double)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
            (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
            (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
            (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
            (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
            (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
            0.000000000843296 * (t * t * rh * rh * rh)) -
            (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return index;
        }
    }
}