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
        public event EventHandler<WeatherDataEventArgs> RaiseWeatherDataChangedEvent;//事件绑定多个方法

        private void OnRaiseWeatherDataChangedEvent(WeatherDataEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<WeatherDataEventArgs> handler = RaiseWeatherDataChangedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void UpdateWeatherData(float temp, float humid, float pres) 
        {
            //TODO:更新
            NotifyDisplays(temp, humid, pres);
        }
        private void NotifyDisplays(float temp, float humid, float pres)
        {
           /* OnRaiseWeatherDataChangedEvent
                 (new WeatherDataEventArgs(new WeatherData(temp, humid, pres)));*/
            RaiseWeatherDataChangedEvent(this, new WeatherDataEventArgs(new WeatherData(temp, humid, pres)));
        }

        public void Dispose()
        {
            if (RaiseWeatherDataChangedEvent != null)
            {
                foreach (EventHandler<WeatherDataEventArgs>
                item in RaiseWeatherDataChangedEvent.GetInvocationList())
                {
                    RaiseWeatherDataChangedEvent -= item;
                }
            }
        }

    }
}
