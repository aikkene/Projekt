using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using projekt.Models;

namespace projekt
{
    public class PogodaClient
    {
        private readonly string apiKey;

        public PogodaClient()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
        public async Task<PogodaResponse> GetWeatherAsync(string miasto)
        {
            if (string.IsNullOrWhiteSpace(miasto))
                throw new ArgumentException("Miasto jest wymagane.", nameof(miasto));

            using var hc = new HttpClient();
            var ce = Uri.EscapeDataString(miasto);
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={ce}&appid=3d7c8f1b44ab5682c7c0fc7e8b28bc65&units=metric";
            var res = await hc.GetAsync(url);
            if (!res.IsSuccessStatusCode)
            {
                var msg = await res.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API error: {(int)res.StatusCode} {res.ReasonPhrase} - {msg}");
            }

            var c = await res.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weather = JsonSerializer.Deserialize<PogodaResponse>(c, options);

            return weather;
        }
    }
}
