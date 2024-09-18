using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using WeatherAppBackend.DTOs;

namespace WeatherAppBackend
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _apiKey = "f011f57e6dfa44c0a09204906241609";
        private readonly string _baseUrl = "https://api.weatherapi.com/v1";
        public WeatherService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<ApiWeatherResponse> GetCurrentWeatherByCityAsync(string city)
        {
            string cacheKey = $"WeatherData_{city}";
            // checking if data is available in the cache
            if(_cache.TryGetValue(cacheKey, out ApiWeatherResponse cachedWeatherData))
            {
                return cachedWeatherData;
            }

            //if not in cache,fetch from weather API
            var response = await _httpClient.GetAsync($"{_baseUrl}/current.json?key={_apiKey}&q={city}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiWeatherResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _cache.Set(cacheKey, apiResponse, TimeSpan.FromMinutes(10));
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
                    FeelsLikeCelsius = apiResponse.Current.Feelslike_c,//FeelslikeC
                    FeelsLikeFahrenheit = apiResponse.Current.Feelslike_f//FeelslikeF
                },
                Wind = new WindDto
                {
                    SpeedMph = apiResponse.Current.Wind_mph,
                    SpeedKph = apiResponse.Current.Wind_kph,
                    Degree = apiResponse.Current.Wind_degree,
                    Direction = apiResponse.Current.Wind_dir
                },
                Pressure = new PressureDto
                {
                    PressureMb = apiResponse.Current.Pressure_mb,
                    PressureIn = apiResponse.Current.Pressure_in
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
