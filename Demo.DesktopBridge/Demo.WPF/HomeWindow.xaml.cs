using Demo.WinFrom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Windows.UI.Notifications;

namespace Demo.WPF
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window, IConvertCallback
    {
        public ObservableCollection<Currency> History { get; set; }
        int count;

        public HomeWindow()
        {
            InitializeComponent();

            History = new ObservableCollection<Currency>();

            var currencyConverter = new CurrencyConverter();
            currencyConverter.ConvertCallback = this;

            windowsFormsHost.Child = currencyConverter;
        }

        public void OnCurrencyConverted(Currency currency)
        {
            History.Add(currency);

            historyGrid.ItemsSource = History;

            if (IsRunningAsUwp())
            {
                count++;
                ShowToastNotification("Success", count + " conversion completed.");
            }
        }

        private async void OpenChartClick(object sender, RoutedEventArgs e)
        {
            if (IsRunningAsUwp())
            {
                if (History.Count == 0)
                {
                    MessageBox.Show("Please do some conversion before open the UWP Chart.");
                }
                else
                {
                    string currencies = "[";

                    foreach (var currency in History)
                    {
                        currencies += "{\"Name\":\"" + currency.Name + "\", \"Code\":\"" + currency.Code + "\", \"Rate\":" + currency.Rate + ", \"ConvertedDate\":\"" + currency.ConvertedDate.ToString() + "\"}, ";
                    }

                    currencies = currencies.Remove(currencies.Length - 2);
                    currencies += "]";

                    Uri uri = new Uri("demo.uwp.protocol://" + "message?content=" + currencies);
                    await Windows.System.Launcher.LaunchUriAsync(uri);
                }
            }
            else
            {
                MessageBox.Show("App is not running as UWP application", "Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // UWP Related Codes
        // Added following three references to compile UWP codes inside WPF
        // 1. Nueget : DesktopBridge.Helpers
        // 2. File   : c:\Program Files (x86)\Windows Kits\10\UnionMetadata\10.0.15063.0\Windows.winmd
        // 3. File   : c:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5\System.Runtime.WindowsRuntime.dll

        public static bool IsRunningAsUwp()
        {
            DesktopBridge.Helpers helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }

        public void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml)
            {
                ExpirationTime = DateTime.Now.AddSeconds(5)
            };

            ToastNotifier.Show(toast);
        }
    }
}
