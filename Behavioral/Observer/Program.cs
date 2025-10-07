using System;
using System.Collections.Generic;

namespace Observer
{
    // Observer interface
    public interface IObserver
    {
        void Update(string message);
    }

    // Subject interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Concrete Subject
    public class WeatherStation : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string weather;

        public string Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine($"WeatherStation: Attached an observer");
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Console.WriteLine($"WeatherStation: Detached an observer");
            observers.Remove(observer);
        }

        public void Notify()
        {
            Console.WriteLine("WeatherStation: Notifying observers...");
            foreach (var observer in observers)
            {
                observer.Update(weather);
            }
        }
    }

    // Concrete Observers
    public class PhoneDisplay : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Phone Display: Weather updated to {message}");
        }
    }

    public class WindowDisplay : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Window Display: Weather updated to {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Observer Pattern Demo ===\n");

            // Create subject
            var weatherStation = new WeatherStation();

            // Create observers
            var phoneDisplay = new PhoneDisplay();
            var windowDisplay = new WindowDisplay();

            // Attach observers
            weatherStation.Attach(phoneDisplay);
            weatherStation.Attach(windowDisplay);

            // Change weather - observers will be notified
            Console.WriteLine("\n--- Setting weather to Sunny ---");
            weatherStation.Weather = "Sunny";

            Console.WriteLine("\n--- Setting weather to Rainy ---");
            weatherStation.Weather = "Rainy";

            // Detach one observer
            Console.WriteLine("\n--- Detaching phone display ---");
            weatherStation.Detach(phoneDisplay);

            Console.WriteLine("\n--- Setting weather to Cloudy ---");
            weatherStation.Weather = "Cloudy";

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
