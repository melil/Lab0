﻿using Lab0.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Lab0
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            getData();

        }
        string city = "Moscow";
        string link = "http://api.openweathermap.org/data/2.5/";
        string appid = "&appid=74fbdf01e3477954c50a164249be6f4f";
        double kalvin = 273.5;
        string urlWeatherUrl = "weather?q=";
        string urlForecastUrl = "forecast?q=";

        public async void getData()
        {

            string weatherUrl = link + urlWeatherUrl + city + appid;
            string forecastUrl = link + urlForecastUrl + city + appid;
            HttpClient client = new HttpClient();

            HttpResponseMessage isaa = await client.GetAsync(weatherUrl);

            string content = await isaa.Content.ReadAsStringAsync();
            var statusCode = isaa.StatusCode;
            string statusCodeString = Convert.ToString(statusCode);
            if (statusCodeString == "OK")
            {
                string response = await client.GetStringAsync(weatherUrl);
                string forecastResponse = await client.GetStringAsync(forecastUrl);






                var weatherData = JsonConvert.DeserializeObject<Rootobject>(response);
                var forecastData = JsonConvert.DeserializeObject<forecastMainData>(forecastResponse);

                var forecastListFucker = JsonConvert.DeserializeObject<forecastMainData>(forecastResponse);

                object forecastTest = forecastData.list.Count.ToString();
                string forecastTexts = Convert.ToString(forecastTest);

                double sredTemp = 0;
                for (int i = 0; i < forecastData.list.Count; i++) //cчитаем среднюю погоду
                {
                    sredTemp = forecastData.list[i].main.temp + sredTemp;
                }
                sredTemp = sredTemp / forecastData.list.Count;



                sredTmp_lbl.Text = Convert.ToString(Math.Round(sredTemp, 1) + "°C");

                string tempe = weatherData.main.temp.ToString();
                double t0c = Convert.ToDouble(tempe);
                t0c = Math.Round((t0c - kalvin), 1);
                if (t0c > 0)
                {
                    result_lbl.Text = " +" + t0c + "°C";
                }
                else if (t0c < 0)
                {
                    result_lbl.Text = t0c + "°C";
                }



                city_lbl.Text = weatherData.name.ToString();
                windSpeed_lbl.Text = " " + weatherData.wind.speed.ToString() + " m/s";
                pressure_lbl.Text = " " + weatherData.main.pressure.ToString() + "mmHg";
                humidity_lbl.Text = " " + weatherData.main.humidity.ToString() + " %";
                //image
                object weather = weatherData.weather[0].main.ToString();
                string weath = Convert.ToString(weather);

                switch (weath)
                {
                    case "Drizzle":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/drizzle.png"));
                        condition_lbl.Text = "Drizzle";
                        break;
                    case "Thunderstorm":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/thunderstorm.png"));
                        condition_lbl.Text = "Thunderstorm";
                        break;
                    case "Rain":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/rain.png"));
                        condition_lbl.Text = "Rain";
                        break;
                    case "Snow":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/snow.png"));
                        condition_lbl.Text = "Snow";
                        break;
                    case "Clear":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/clear.png"));
                        condition_lbl.Text = "Clear";
                        break;
                    case "Clouds":
                        imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/clouds.png"));
                        condition_lbl.Text = "Clouds";
                        break;
                    default:
                        break;

                }
            }
            else if (statusCodeString == "NotFound")
            {
                labName_lbl.Text = "NotFound";
            }




        }

        private void btn_readTown_Click(object sender, RoutedEventArgs e)
        {
            city = PushedText_txb.Text.ToString();
            getData();
        }

    }
}
