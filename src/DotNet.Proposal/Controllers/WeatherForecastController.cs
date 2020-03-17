using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DotNet.Proposal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecretStore _secretStore;

        public WeatherForecastController(IConfiguration configuration, ISecretStore secretStore)
        {
            _configuration = configuration;
            _secretStore = secretStore;
        }

        [HttpGet]
        public async Task<IActionResult> Post(WeatherForecast weatherForecast)
        {
            var apiUrl = _configuration["api:url"];

            // You should not be doing this but it's just to prove the point
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };

            var apiKey = await _secretStore.Get("APIs-Weather-Key");
            httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var rawForecast = JsonConvert.SerializeObject(weatherForecast);
            await httpClient.PostAsync("/weather/report", new StringContent(rawForecast));

            return Ok();
        }
    }
}