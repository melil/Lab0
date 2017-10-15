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

        async void getData()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Moscow,ru&appid=74fbdf01e3477954c50a164249be6f4f";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<Rootobject>(response);
            string tempe = data.main.temp.ToString();
            double t0c = Convert.ToDouble(tempe);
            t0c = Math.Round((t0c - 273.5), 1);


            city_lbl.Text = data.name.ToString();
            result_lbl.Text = t0c + "°C";

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            result_lbl.Text = "work";
        }
    }
}
