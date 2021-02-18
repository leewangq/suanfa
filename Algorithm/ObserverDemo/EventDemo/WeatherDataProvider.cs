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
        public delegate bool WeatherEventHandler<TEventArgs>(object sender, TEventArgs e);//自定义委托

        private event WeatherEventHandler<WeatherDataEventArgs> raiseWeatherDataChangedEvent;
       
        public void BindRaiseWeatherDataChangedEvent(WeatherEventHandler<WeatherDataEventArgs> raiseFunction) 
        {
            this.raiseWeatherDataChangedEvent += raiseFunction;
        }

        public void UnBindRaiseWeatherDataChangedEvent(WeatherEventHandler<WeatherDataEventArgs> raiseFunction)
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
                foreach (WeatherEventHandler<WeatherDataEventArgs>
                item in raiseWeatherDataChangedEvent.GetInvocationList())
                {
                    raiseWeatherDataChangedEvent -= item;
                }
            }
        }

    }
}
