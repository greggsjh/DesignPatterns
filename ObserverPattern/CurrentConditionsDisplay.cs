namespace ObserverPattern
{
    public class CurrentConditionsDisplay : IDisplay, IObserver
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public ISubject Subject { get; set; }

        public CurrentConditionsDisplay(ISubject subject)
        {
            Subject = subject;
            Subject.Subscribe(this);
        }
        public string Display()
        {
            return $"Current Conditions: {Temperature}F degrees and {Humidity}% humidity";
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Humidity = humidity;
            Temperature = temperature;
            Pressure = pressure;
        }
    }
}