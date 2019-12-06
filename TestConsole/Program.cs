using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Task.BLL.Abstracrions;
using Task.BLL.Models;
using Task.BLL.Services;
using Task.DAL.EF;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var forecastList = FillForecastList().ToArray();
            var degreeComparer = new ForecastComparer(30);
           
            Array.Sort(forecastList, degreeComparer);
            
            foreach (var forecastModel in forecastList)
            {
                Console.WriteLine(forecastModel);
            }

            Console.ReadKey();
        }


        private static IEnumerable<ForecastModel> FillForecastList()
        {
            return new ForecastModel[]
            {
                new ForecastModel{Id = 1,Degree = 12},
                new ForecastModel{Id = 2, Degree = 34},
                new ForecastModel{Id = 3, Degree = 30, DateTime = DateTime.Now},
                new ForecastModel{Id = 4, Degree = 15},
                new ForecastModel{Id = 5, Degree = 28, DateTime = DateTime.Now.AddDays(-2)},
                new ForecastModel{Id = 6, Degree = 30,DateTime = DateTime.Now.AddDays(-2)},
                new ForecastModel{Id = 7, Degree = -11},
                new ForecastModel{Id = 8, Degree = 0,DateTime = DateTime.Now.AddDays(-1)},
                new ForecastModel{Id = 9, Degree = 30,DateTime = DateTime.Now.AddDays(-1)},
                new ForecastModel{Id = 10, Degree = -29},
                new ForecastModel{Id = 11, Degree = 28,DateTime = DateTime.Now.AddDays(-1)},
                new ForecastModel{Id = 12, Degree = -11,DateTime = DateTime.Now.AddDays(-1)}
            };
        }

      
    }
}
