using Algorithm.Demo;
using Algorithm.LinkedList;
using Algorithm.ObserveDemo.EventDemo;
using Algorithm.Queue;
using Algorithm.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //AlgorithmDemo.GetContinuousNumBySumEqualsInputNum(15);
            WeatherDataProvider provider = new WeatherDataProvider();
            CurrentConditionsDisplay current = new CurrentConditionsDisplay(provider);
            provider.UpdateWeatherData(1, 2, 3);
            /*  WeatherDataPub weatherDataPub = new WeatherDataPub();
              WeatherDataSub weatherDataSub = new WeatherDataSub(weatherDataPub);
              weatherDataPub.SetMeasurements(10,20,30);
              weatherDataSub.Unsubscribe();*/
            Console.ReadLine();
        }
    }
}
