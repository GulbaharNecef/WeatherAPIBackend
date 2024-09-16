namespace WeatherAppBackend.DTOs
{
    
    public class WeatherGetDTO
    {
        public RealFeelDto RealFeel { get; set; }
        public WindDto Wind { get; set; }
        public PressureDto Pressure { get; set; }
        public int Humidity { get; set; }
        public SunriseSunsetDto SunriseSunset { get; set; }
    }

    public class RealFeelDto
    {
        public double FeelsLikeCelsius { get; set; }
        public double FeelsLikeFahrenheit { get; set; }
    }

    public class WindDto
    {
        public double SpeedMph { get; set; }
        public double SpeedKph { get; set; }
        public int Degree { get; set; }
        public string Direction { get; set; }
    }

    public class PressureDto
    {
        public double PressureMb { get; set; }
        public double PressureIn { get; set; }
    }

    public class SunriseSunsetDto
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }

}
