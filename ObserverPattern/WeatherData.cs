namespace ObserverPattern
{
    public class WeatherData : ISubject
    {
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public IObserver[] Observers { get; set; }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(Temperature, Humidity, Pressure);
            }
        }

        public void Subscribe()
        {
            throw new System.NotImplementedException();
        }

        public void UnSubscribe()
        {
            throw new System.NotImplementedException();
        }
    }
}