namespace DesignPatterns.ObserverPattern
{
    public class ForecastDisplay : IDisplay, IObserver
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public ISubject Subject { get; set; }

        public ForecastDisplay(ISubject subject)
        {
            Subject = subject;
            Subject.Subscribe(this);
        }
        public string Display()
        {
            if (Temperature >= 90)
            {
                return "Forecast: It's gonna' be a hot one today!";
            }
            else if (Temperature >= 80 && Temperature < 90)
            {
                return "Forecast: Warming up today!";
            }
            else if (Temperature >= 70 && Temperature < 80)
            {
                return "Forecast: Comfortable and warmer.";
            }
            else if (Temperature >= 60 && Temperature < 70)
            {
                return "Forecast: Comfortable and cooler.";
            }
            else if (Temperature >= 50 && Temperature < 60)
            {
                return "Forecast: Brisk today.";
            }
            else if (Temperature >= 40 && Temperature < 50)
            {
                return "Forecast: Colder today.";
            }
            else if (Temperature >= 32 && Temperature < 40)
            {
                return "Forecast: Cold.";
            }
            else if (Temperature >= 20 && Temperature < 32)
            {
                return "Forecast: Freezing temps today. Brrrr!";
            }
            else
            {
                return "Forecast: Frigid, artic air. Stay indoors where it's warm!";
            }
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Humidity = humidity;
            Temperature = temperature;
            Pressure = pressure;
        }
    }
}