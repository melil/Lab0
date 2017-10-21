using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Model
{


    public class Rootobject
    {


        public Coord coord { get; set; }

        public List<Weather> weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        private double _pressure;
        public double pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value * 0.750063755419211;
                _pressure = Math.Round(_pressure, 0);
            }
        }
        public int humidity { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }


    /*  / forecast 
        /
        /    
        /
        /
        /
        /
    */
    public class forecastMainData
    {
        public string cod { get; set; }
        public float message { get; set; }
        public int cnt { get; set; }
        public List<forecastList> list { get; set; }
        public forecastCity city { get; set; }
    }

    public class forecastCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public forecastCoord coord { get; set; }
        public string country { get; set; }
    }

    public class forecastCoord
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class forecastList
    {
        public int dt { get; set; }
        public forecastMainMain main { get; set; }
        public forecastWeather[] weather { get; set; }
        public forecastClouds clouds { get; set; }
        public forecastWind wind { get; set; }
        public forecastRain rain { get; set; }
        public forecastSys sys { get; set; }
        public string dt_txt { get; set; }
        public forecastSnow snow { get; set; }
    }

    public class forecastMainMain
    {
        private double _temp;
        public double temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15;
            }
        }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        // public double pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }
        public int humidity { get; set; }
        public float temp_kf { get; set; }
    }

    public class forecastClouds
    {
        public int all { get; set; }
    }

    public class forecastWind
    {
        public float speed { get; set; }
        public float deg { get; set; }
    }

    public class forecastRain
    {
        public float _3h { get; set; }
    }

    public class forecastSys
    {
        public string pod { get; set; }
    }

    public class forecastSnow
    {
        public float _3h { get; set; }
    }

    public class forecastWeather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }


}
