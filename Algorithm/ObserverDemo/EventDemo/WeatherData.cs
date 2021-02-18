using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.EventDemo
{
    public class WeatherData
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }

        public WeatherData(float temp, float humid, float pres)
        {
            Temperature = temp;
            Humidity = humid;
            Pressure = pres;
        }
    }
}
