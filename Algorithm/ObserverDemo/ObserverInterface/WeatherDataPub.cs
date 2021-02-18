using Algorithm.ObserveDemo.EventDemo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.ObserveDemo.ObserveInterface
{
    /// <summary>
    /// 天气发布者
    /// </summary>
    public class WeatherDataPub : IObservable<WeatherData>
    {
        List<IObserver<WeatherData>> observers;

        public WeatherDataPub()
        {
            observers = new List<IObserver<WeatherData>>();
        }


        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new UnSubscriber(observers, observer);
        }
        private void MeasurementsChanged(float temp, float humid, float pres)
        {
            foreach (var obs in observers)
            {
                obs.OnNext(new WeatherData(temp, humid, pres));
            }
        }

        public void SetMeasurements(float temp, float humid, float pres)
        {
            MeasurementsChanged(temp, humid, pres);
        }

        private class UnSubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> lstObservers;
            private IObserver<WeatherData> observer;

            public UnSubscriber(List<IObserver<WeatherData>> ObserversCollection,
                                IObserver<WeatherData> observer)
            {
                this.lstObservers = ObserversCollection;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (this.observer != null)
                {
                    lstObservers.Remove(this.observer);
                }
            }
        }

    }
}
