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
        public string TzId { get; set; }
        public long LocaltimeEpoch { get; set; }
        public string Localtime { get; set; }
    }

    public class CurrentDto
    {
        public long LastUpdatedEpoch { get; set; }
        public string LastUpdated { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public int IsDay { get; set; }
        public ConditionDto Condition { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public int WindDegree { get; set; }
        public string WindDir { get; set; }
        public double PressureMb { get; set; }
        public double PressureIn { get; set; }
        public double PrecipMm { get; set; }
        public double PrecipIn { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public double FeelslikeC { get; set; }
        public double FeelslikeF { get; set; }
        public double WindchillC { get; set; }
        public double WindchillF { get; set; }
        public double HeatindexC { get; set; }
        public double HeatindexF { get; set; }
        public double DewpointC { get; set; }
        public double DewpointF { get; set; }
        public double VisKm { get; set; }
        public double VisMiles { get; set; }
        public double Uv { get; set; }
        public double GustMph { get; set; }
        public double GustKph { get; set; }
    }

    public class ConditionDto
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }
}
