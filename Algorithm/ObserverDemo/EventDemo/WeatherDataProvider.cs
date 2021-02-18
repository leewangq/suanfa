using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.EventDemo
{
    /// <summary>
    /// 发布者
    /// </summary>
    public class WeatherDataProvider: IDisposable
    {
        private event EventHandler<WeatherDataEventArgs> raiseWeatherDataChangedEvent;
       
        public void BindRaiseWeatherDataChangedEvent(EventHandler<WeatherDataEventArgs> raiseFunction) 
        {
            this.raiseWeatherDataChangedEvent += raiseFunction;
        }

        public void UnBindRaiseWeatherDataChangedEvent(EventHandler<WeatherDataEventArgs> raiseFunction)
        {
            this.raiseWeatherDataChangedEvent -= raiseFunction;
        }

        public void UpdateWeatherData(float temp, float humid, float pres) 
        {
            raiseWeatherDataChangedEvent(this, new WeatherDataEventArgs(new WeatherData(temp, humid, pres)));//触发事件
        }

        public void Dispose()
        {
            if (raiseWeatherDataChangedEvent != null)
            {
                foreach (EventHandler<WeatherDataEventArgs>
                item in raiseWeatherDataChangedEvent.GetInvocationList())
                {
                    raiseWeatherDataChangedEvent -= item;
                }
            }
        }

    }
}
