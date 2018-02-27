using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Parameter.ToString());
                try
                {
                    var message = decoder.GetFirstValueByName("content");

                    List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(message);

                    (BarChart.Series[0] as BarSeries).ItemsSource = currencies;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("MainPage OnNavigatedTo Error: " + ex.Message);
                }
            }
        }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Rate { get; set; }
        public DateTime ConvertedDate { get; set; }
    }
}
