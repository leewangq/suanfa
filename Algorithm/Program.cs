using Algorithm.ObserveDemo.EventDemo;
using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherDataEventPub = new WeatherDataEventPub();
            var weatherDataEventSub = new WeatherDataEventSub(weatherDataEventPub);
            weatherDataEventPub.UpdateWeatherData(1, 2, 3);

            /*  WeatherDataPub weatherDataPub = new WeatherDataPub();
              WeatherDataSub weatherDataSub = new WeatherDataSub(weatherDataPub);
              weatherDataPub.SetMeasurements(10,20,30);
              weatherDataSub.Unsubscribe();*/

            //var list = new List<int> {1,2,3,4,5,6 };
            //var result=ParallelDemo.GetSum(list);
            //Console.WriteLine(list.AsParallel().Sum());

            Console.ReadLine();
        }
    }
}
