using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        
        [HttpGet("current{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weatherData = await _weatherService.GetCurrentWeatherByCityAsync(city);
            if (weatherData == null)
            {
                return NotFound();
            }
            return Ok(weatherData);

        }
        [HttpGet("forecast{city}")]
        public async Task<IActionResult> GetForecast(string city)
        {
            var forecastData = await _weatherService.GetForecastByCityAsync(city);
            if (forecastData == null)
            {
                return NotFound();
            }
            return Ok(forecastData);

        }
    }
}
