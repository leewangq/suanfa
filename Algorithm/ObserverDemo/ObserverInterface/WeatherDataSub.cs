using Algorithm.ObserveDemo.EventDemo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.ObserveInterface
{
    /// <summary>
    /// 天气订阅者
    /// </summary>
    public class WeatherDataSub : IObserver<WeatherData>
    {
        WeatherData data;
        private IDisposable unsubscriber;

        public WeatherDataSub(IObservable<WeatherData> provider) 
        {
            unsubscriber = provider.Subscribe(this);
        }

        public void Display()
        {
            Console.WriteLine("Current Conditions : Temperature ={0}| Humidity = {1}% | Pressure = {2} bar", data.Temperature, data.Humidity, data.Pressure);
        }

        public void Subscribe(IObservable<WeatherData> provider)
        {
            if (unsubscriber == null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Some error has occurred..");
        }

        public void OnNext(WeatherData value)
        {
            this.data = value;
            Display();
        }

    }
}
