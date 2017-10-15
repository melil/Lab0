using Lab0.Model;
using Newtonsoft.Json;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            getData();
        }

        string city = "Moscow,ru";
        string link = "http://api.openweathermap.org/data/2.5/weather?q=";
        string appid = "&appid=74fbdf01e3477954c50a164249be6f4f";


        public async void getData()
        {

            string url = link + city + appid;
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<Rootobject>(response);
            string tempe = data.main.temp.ToString();
            double t0c = Convert.ToDouble(tempe);
            t0c = Math.Round((t0c - 273.5), 1);
            object weather = data.weather[0].main.ToString();

            string weath = Convert.ToString(weather);

            switch (weath)
            {
                case "Drizzle":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/drizzle.png"));
                    break;
                case "Thunderstorm":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/thunderstorm.png"));
                    break;
                case "Rain":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/rain.png"));
                    break;
                case "Snow":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/snow.png"));
                    break;
                case "Clear":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/clear.png"));
                    break;
                case "Clouds":
                    imgWeather.Source = new BitmapImage(new Uri("ms-appx:/Assets/WeatherIcons/clouds.png"));
                    break;
                default:
                    break;
                    
            }
            city_lbl.Text = data.name.ToString();
            result_lbl.Text = t0c + "°C";
        }

        private void btn_voronezh_Click(object sender, RoutedEventArgs e)
        {
            city = "Voronezh";
            getData();
        }
        private void btn_sochi_Click(object sender, RoutedEventArgs e)
        {
            city = "Sochi";
            getData();

        }
        private void btn_defaultCity_Click(object sender, RoutedEventArgs e)
        {
            city = "Moscow";
            getData();
        }

    }
}
