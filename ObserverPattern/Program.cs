using System;
using ObserverPattern.BuiltInObserver;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            TemperatureReporter temperatureReporter = new TemperatureReporter();

            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);
            CurrentTemperatureDisplay currentTemperatureDisplay = new CurrentTemperatureDisplay(temperatureReporter);

            Temperature t = new Temperature { Temp = 80 };
            temperatureReporter.TemperatureChanged(t);

            t.Temp = 82;
            temperatureReporter.TemperatureChanged(t);
            Console.WriteLine(currentTemperatureDisplay.Display());

            t.Temp = 78;
            temperatureReporter.TemperatureChanged(t);
            Console.WriteLine(currentTemperatureDisplay.Display());

            weatherData.SetMeasurements(80, 65, 30.4);
            weatherData.SetMeasurements(82, 70, 29.2);
            weatherData.SetMeasurements(78, 90, 29.2);

            Console.WriteLine(currentConditionsDisplay.Display());
            Console.WriteLine(statisticsDisplay.Display());
            Console.WriteLine(forecastDisplay.Display());
            Console.WriteLine(heatIndexDisplay.Display());
            Console.Read();
        }
    }
}
