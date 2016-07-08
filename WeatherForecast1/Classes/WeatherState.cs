using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast1.Classes
{
    [Newtonsoft.Json.JsonObject(Title = "List")]
    public class WeatherState
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double rain { get; set; }

        public DateTime Date
        {
            get
            {
                if (dt != 0)
                {
                    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(dt).ToLocalTime();
                    return dtDateTime;
                }

                return DateTime.Now;
            }
        }
    }
}