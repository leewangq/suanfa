using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.EventDemo
{
    /// <summary>
    /// 订阅者
    /// </summary>
    public class CurrentConditionsDisplay
    {
        WeatherData data;
        WeatherDataProvider WDprovider;

        public CurrentConditionsDisplay(WeatherDataProvider provider)
        {
            WDprovider = provider;
            WDprovider.BindRaiseWeatherDataChangedEvent(provider_RaiseWeatherDataChangedEvent);
        }

        private void provider_RaiseWeatherDataChangedEvent(object sender, WeatherDataEventArgs e)
        {
            data = e.data;
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            Console.WriteLine("Current Conditions : Temperature ={0}| Humidity = {1}% | Pressure = {2} bar", data.Temperature, data.Humidity, data.Pressure);
        }

        public void Unsubscribe()
        {
            WDprovider.UnBindRaiseWeatherDataChangedEvent(provider_RaiseWeatherDataChangedEvent);
        }

    }
}
