using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Demo.WinFrom
{
    public partial class CurrencyConverter: UserControl
    {
        string[] currencyCode = { "AUD", "BGN", "BRL", "CAD", "CHF", "CNY", "CZK", "DKK", "EUR", "GBP", "HKD", "HRK", "HUF", "IDR", "ILS", "INR", "JPY", "KRW", "MXN", "MYR", "NOK", "NZD", "PHP", "PLN", "RON", "RUB", "SEK", "SGD", "THB", "TRY", "USD", "ZAR" };
        string[] currencyName = { "Australian Dollar", "Bulgarian Lev", "Brazilian Real", "Canadian Dollar", "Swiss Franc", "Chinese Yuan", "Czech Koruna", "Danish Krone", "Euro", "British Pound", "Hong Kong Dollar", "Croatian Kuna", "Hungarian Forint", "Indonesian Rupiah", "Israeli Shekel", "Indian Rupee", "Japanese Yen", "Korean Won", "Mexican Peso", "Malaysian Ringgit", "Norwegian Krone", "New Zealand Dollar", "Philippine Peso", "Polish Zloty", "Romanian Leu", "Russian Rouble", "Swedish Krona", "Singapore Dollar", "Thai Baht", "Turkey Lira", "South African Rand" };

        public IConvertCallback ConvertCallback { get; set; }

        public CurrencyConverter()
        {
            InitializeComponent();
        }

        private async void buttonConvert_Click(object sender, EventArgs e)
        {
            if (comboBoxTo.SelectedIndex == -1)
            {
                MessageBox.Show("Select valid currency");
            }
            else
            {
                string to = currencyCode[comboBoxTo.SelectedIndex];

                string url = "https://api.fixer.io/latest?base=USD&symbols=" + to;
                string response = await GetAsync(url);

                dynamic parsed = JObject.Parse(response);
                double rate = parsed["rates"][to];

                labelRate.Text = "Rate : " + rate;

                if (ConvertCallback != null)
                {
                    ConvertCallback.OnCurrencyConverted(new Currency { Name = currencyName[comboBoxTo.SelectedIndex], Code = to, Rate = rate, ConvertedDate = DateTime.Now });
                }
            }
        }

        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
