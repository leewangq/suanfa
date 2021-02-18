using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.EventDemo
{
    public class WeatherDataEventArgs:EventArgs
    {
        public WeatherData data { get; private set; }
        public WeatherDataEventArgs(WeatherData data)
        {
            this.data = data;
        }

    }
}
