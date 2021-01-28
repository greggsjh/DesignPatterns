namespace DesignPatterns.ObserverPattern.BuiltInObserver
{
    public class Temperature
    {
        public double Temp { get; set; }
        public Temperature()
        {

        }
        public Temperature(double temp)
        {
            Temp = temp;
        }
    }
}