﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Task.BLL.Abstracrions;
using Task.BLL.Models;
using Task.DAL.EF;
using Task.DAL.Entities;

namespace Task.BLL.Services
{
    public class ForecastService : IForecastService
    {
        public int Degree { get; }
        private const string Url =
            "http://dataservice.accuweather.com/forecasts/v1/daily/5day/222191?apikey=";
        private readonly ApplicationDbContext _dbContext;

        public ForecastService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Degree = GetDegreeFromJson();
        }

        public void Add(ForecastModel model)
        {
            var player = new Player { Phone = model.Phone, Name = model.PlayerName };
            var forecast = new Forecast
            {
                Degree = model.Degree,
                Player = player,
                DateTime = DateTime.Now
            };
            _dbContext.Forecasts.Add(forecast);
            _dbContext.SaveChanges();
        }
        public IEnumerable<ForecastModel> Get()
        {
            var forecasts = _dbContext.Forecasts.Select(x => new ForecastModel
            {
                Id = x.Id,
                Phone = x.Player.Phone,
                Degree = x.Degree,
                PlayerName = x.Player.Name,
                DateTime = x.DateTime
            });
            var result = GetListResults(forecasts.ToArray());
            return result;
        }



      
        private IEnumerable<ForecastModel> GetListResults(ForecastModel[] data)
        {
            var comparer = new ForecastComparer(Degree);
            Array.Sort(data, comparer);
            return data;
        }

        private int GetCelsiumByForengeyt(int f)
        {
            var c = (f - 32) * 5 / 9;
            return c;
        }

        private string GetStringFromAPI(string apiKey)
        {
            string value = string.Empty;
            using (WebClient client = new WebClient())
            {
                value = client.DownloadString(Url + apiKey);
            }
            return value;
        }
        private int GetDegreeFromJson()
        {
            string value = "0";
            var stringData = GetStringFromAPI("SUbAqLoPglknQ60E9TDwd3gTtGUdMUWZ");
            var definition = new { DailyForecasts = new[] { new { Temperature = new { Minimum = new { Value = "" } } } } };
            var obj = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(stringData, definition);
            value = obj.DailyForecasts[1].Temperature.Minimum.Value;
            var resStr = value.Split('.')[0];
            return GetCelsiumByForengeyt(int.Parse(resStr));
        }
    }
}