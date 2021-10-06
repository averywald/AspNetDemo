using AspNet.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspNet.Services
{
    public class WeatherForecastService
    {
        private List<WeatherForecast> _forecasts { get; set; }
        private int _lastId
        {
            get => this._forecasts.LastOrDefault().Id;
        }

        private int _nextId
        {
            get => this._lastId + 1;
        }
        
        public WeatherForecastService()
        {
            string[] Summaries = new string[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var rng = new Random(); // init randomization seed
            int i = 0;

            var e = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = i++,

                // generate randomized dataset
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            Console.WriteLine(e);

            this._forecasts = new List<WeatherForecast>();
            // insert into Service's Model collection
            this._forecasts.AddRange(e);
        }

        public List<WeatherForecast> GetAll()
        {
            return this._forecasts;
        }

        public WeatherForecast GetForecast(int id)
        {
            // linq query to find forecast item by ID
            IEnumerable<WeatherForecast> queryResult = 
                from f in this._forecasts
                where f.Id == id
                select f;

            return queryResult.First<WeatherForecast>();
        }

        public void Add(WeatherForecast forecast)
        {
            this._forecasts.Add(forecast);
        }

        public void Add(int id, string dateFormatted, int tempC, string summary)
        {
            this._forecasts.Add(new WeatherForecast
            {
                Id = id,
                DateFormatted = dateFormatted,
                TemperatureC = tempC,
                Summary = summary
            });
        }
    }
}