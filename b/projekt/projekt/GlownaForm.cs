using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace projekt
{
    public partial class GlownaForm : Form
    {
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

            try
            {
                var client = new PogodaClient();
                var weather = await client.GetWeatherAsync(city);
                var desc = weather.Weather?.Length > 0 ? weather.Weather[0].Description : "brak danych";
                var temp = weather.Main?.Temp ?? double.NaN;
                MessageBox.Show(this, $"Miasto: {city}\nPogoda: {desc}\nTemperatura: {temp} °C", "Pogoda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
