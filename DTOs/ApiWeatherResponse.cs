namespace WeatherAppBackend.DTOs
{

    public class ApiWeatherResponse
    {
        public LocationDto Location { get; set; }
        public CurrentDto Current { get; set; }
    }

    public class LocationDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Tz_id { get; set; }
        public long Localtime_epoch { get; set; }
        public string Localtime { get; set; }
    }

    public class CurrentDto
    {
        public long Last_updated_epoch { get; set; }
        public string Last_updated { get; set; }
        public double Temp_c { get; set; }
        public double Temp_f { get; set; }
        public int Is_day { get; set; }
        public ConditionDto Condition { get; set; }
        public double Wind_mph { get; set; }
        public double Wind_kph { get; set; }
        public int Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public double Pressure_mb { get; set; }
        public double Pressure_in { get; set; }
        public double Precip_mm { get; set; }
        public double Precip_in { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public double Feelslike_c { get; set; }//FeelslikeC
        public double Feelslike_f { get; set; }//FeelslikeF
        public double Windchill_c { get; set; }//WindchillC
        public double Windchill_f { get; set; }
        public double Heatindex_c { get; set; }
        public double Heatindex_f { get; set; }
        public double Dewpoint_c { get; set; }
        public double Dewpoint_f { get; set; }
        public double Vis_km { get; set; }
        public double Vis_miles { get; set; }
        public double Uv { get; set; }
        public double Gust_mph { get; set; }
        public double Gust_kph { get; set; }
    }

    public class ConditionDto
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }
}
