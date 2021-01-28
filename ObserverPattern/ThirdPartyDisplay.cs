namespace DesignPatterns.ObserverPattern
{
    public class ThirdPartyDisplay : IDisplay, IObserver
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public ISubject Subject { get; set; }

        public string Display()
        {
            return $"Current Temperature: {Temperature}F \nCurrent Humidity: {Humidity}% \nBarometric Pressure: {Pressure}";
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Humidity = humidity;
            Temperature = temperature;
            Pressure = pressure;
        }
    }
}