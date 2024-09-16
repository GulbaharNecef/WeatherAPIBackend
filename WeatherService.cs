using System.Text.Json;
using WeatherAppBackend.DTOs;

namespace WeatherAppBackend
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "f011f57e6dfa44c0a09204906241609";
        private readonly string _baseUrl = "https://api.weatherapi.com/v1";
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiWeatherResponse> GetCurrentWeatherByCityAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/current.json?key={_apiKey}&q={city}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiWeatherResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return apiResponse;

            }
            return null;
        }

        public async Task<string> GetForecastByCityAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/forecast.json?key={_apiKey}&q={city}&days={6}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        public WeatherGetDTO MapToDto(ApiWeatherResponse apiResponse)
        {
            return new WeatherGetDTO
            {
                RealFeel = new RealFeelDto
                {
                    FeelsLikeCelsius = apiResponse.Current.FeelslikeC,
                    FeelsLikeFahrenheit = apiResponse.Current.FeelslikeF
                },
                Wind = new WindDto
                {
                    SpeedMph = apiResponse.Current.WindMph,
                    SpeedKph = apiResponse.Current.WindKph,
                    Degree = apiResponse.Current.WindDegree,
                    Direction = apiResponse.Current.WindDir
                },
                Pressure = new PressureDto
                {
                    PressureMb = apiResponse.Current.PressureMb,
                    PressureIn = apiResponse.Current.PressureIn
                },
                Humidity = apiResponse.Current.Humidity,
                SunriseSunset = new SunriseSunsetDto
                {
                    // Placeholder values for Sunrise and Sunset, as they are not in the provided response
                    Sunrise = "Not Available",
                    Sunset = "Not Available"
                }
            };
        }
    }
}
