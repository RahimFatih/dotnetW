using System;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace zad2
{
    public class Coord
    {
        public float lon;
        public float lat;
    }
    public class Weather
    {
        public int id;
        public string main;
        public string description;
    }
    public class MainWeather
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public float pressure;
        public float humidity;
    }
    public class Wind
    {
        public float speed;
        public float deg;
    }
    public class Clouds
    {
        public float all;
    }
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public float sunrise;
        public float sunset;
    }
    public class DownloadWeather
    {
        public Coord coord {get;set;}
        public Weather[] weather {get;set;}
        public MainWeather main {get;set;}
        public float visibility {get;set;}
        public Wind wind{get;set;}
        public Clouds clouds{get;set;}
        public int dt{get;set;}
        public Sys sys{get;set;}
        public int timezone { get; set; }
        public int id {get;set;}
        public string name { get; set; }
        public int cod{get;set;}

        public string getWeather(string City)
        {
            using(WebClient web = new WebClient())
            {
                string url =string.Format("https://api.openweathermap.org/data/2.5/weather?q="+City+"&appid=b0789adf874bd65919c23b49a964d714&units=metric");
                var json = web.DownloadString(url);
                return json;
            }
        }

    }
        public class WeatherForDB
    {
        public string clouds {get;set;}
        public float temp  {get;set;}
        public float feels_like {get;set;}
        public float temp_min {get;set;}
        public float temp_max {get;set;}
        public float pressure {get;set;}
        public float humidity {get;set;}
        public float windSpeed {get;set;}
        public float windDeg {get;set;}
        public string id {get;set;}
        public string name {get;set;}
        
    
        public int getWeather(DownloadWeather myWeather)
        {
            clouds = myWeather.weather[0].description;
            temp = myWeather.main.temp;
            feels_like = myWeather.main.feels_like;
            temp_min = myWeather.main.temp_min;
            temp_max = myWeather.main.temp_max;
            pressure = myWeather.main.pressure;
            humidity = myWeather.main.humidity;
            windSpeed = myWeather.wind.speed;
            windDeg = myWeather.wind.deg;
            id =DateTime.Now.ToString("yyyyMMddHHmmssffff");
            name = myWeather.name;
            return 0; 
        }

    }
    public class WeatherByCity: DbContext
    {
        public virtual DbSet<WeatherForDB> WeatherForDB {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\database\blogging.db");
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new WeatherByCity();
            string choosenCity;
            DownloadWeather myWeather = new DownloadWeather();
            DownloadWeather actualWeather;
            WeatherForDB actualWeatherForDB = new WeatherForDB();

            Console.WriteLine("1. Sprawdz pogode \n2. Pokaz historie dla miasta");
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Podaj miasto: ");
                    choosenCity = Console.ReadLine();
                    actualWeather = JsonConvert.DeserializeObject<DownloadWeather>(myWeather.getWeather(choosenCity));
                    actualWeatherForDB.getWeather(actualWeather);
                    Console.WriteLine("Miasto: " + actualWeather.name);
                    Console.WriteLine("Kraj: " + actualWeather.sys.country);
                    Console.WriteLine("Temperatura: " + actualWeather.main.temp+"°C");
                    Console.WriteLine("Zachmurzenie: " + actualWeather.weather[0].description);            
                    context.WeatherForDB.Add(actualWeatherForDB);
                    context.SaveChanges();
                    break;
                case 2:
                    Console.WriteLine("Podaj miasto");
                    choosenCity = Console.ReadLine();
                    Console.WriteLine("SELECT * FROM WeatherForDB WHERE name = '"+choosenCity+"'");
                    var pogody = context.WeatherForDB.FromSqlRaw("SELECT * FROM WeatherForDB WHERE name = '"+choosenCity+"'");//.ToList<DownloadWeather>();
                    foreach(var pogoda in pogody)
                    {
                        Console.WriteLine(pogoda.id.Substring(0,4)+"-"+pogoda.id.Substring(4,2)+"-"+pogoda.id.Substring(6,2)+" Temperatura: "+pogoda.temp+"°C");//+" "+pogoda.id.Substring(0,4)+" ");
                    }
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji");
                    break;
            }
            
                
        }

        
    }
}
