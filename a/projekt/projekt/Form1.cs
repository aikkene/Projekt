using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class GlownaForm : Form
    {
        private readonly PogodaClient _client = new PogodaClient();

        public GlownaForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var city = miasto.Text?.Trim();
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show(this, "Podaj nazwę miasta.", "Brak miasta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = new PogodaClient();
            var weather = await client.GetWeatherAsync(city);
            var desc = weather?.Weather?.Length > 0 ? weather.Weather[0].Description : "brak danych";
            var temp = weather?.Main?.Temp ?? double.NaN;
            MessageBox.Show(this, $"Miasto: {city}\nPogoda: {desc}\nTemperatura: {temp} °C", "Pogoda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    public class PogodaResponse
    {
        public string Name { get; set; }
        public Pogoda[] Weather { get; set; }
        public Glowne Main { get; set; }
    }

    public class Pogoda
    {
        public string Description { get; set; }
    }

    public class Glowne
    {
        public double? Temp { get; set; }
    }
    public class PogodaClient : IDisposable
    {
        private readonly HttpClient _hc = new HttpClient();
        private readonly string _apiKey;
        private bool _disposed;

        public PogodaClient(string apiKey = null)
        {
            _apiKey = apiKey ?? Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY") ?? "3d7c8f1b44ab5682c7c0fc7e8b28bc65";
        }

        public async Task<PogodaResponse> GetWeatherAsync(string miasto)
        {
            if (string.IsNullOrWhiteSpace(miasto))
                throw new ArgumentException("Miasto jest wymagane.", nameof(miasto));

            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new InvalidOperationException("Brak klucza API OpenWeather. Ustaw zmienną środowiskową OPENWEATHER_API_KEY.");

            var ce = Uri.EscapeDataString(miasto);
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={ce}&appid={_apiKey}&units=metric&lang=pl";
            using var res = await _hc.GetAsync(url).ConfigureAwait(false);
            if (!res.IsSuccessStatusCode)
            {
                var msg = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new HttpRequestException($"API error: {(int)res.StatusCode} {res.ReasonPhrase} - {msg}");
            }

            var c = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weather = JsonSerializer.Deserialize<PogodaResponse>(c, options);

            return weather;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _hc.Dispose();
            _disposed = true;
        }
    }
}
