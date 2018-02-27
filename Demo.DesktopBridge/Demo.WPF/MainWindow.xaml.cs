using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Notifications;

namespace Demo.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowToastClick(object sender, RoutedEventArgs e)
        {
            if (IsRunningAsUwp())
            {
                ShowToastNotification("Title", "This is simple UWP Toast Notification!");
            }
            else
            {
                MessageBox.Show("App is not running as UWP application", "Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void OpenUWPPageClick(object sender, RoutedEventArgs e)
        {
            if (IsRunningAsUwp())
            {
                Uri uri = new Uri("demo.uwp.protocol://" + "message?content=" + txtPageMessage.Text);
                await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            else
            {
                MessageBox.Show("App is not running as UWP application", "Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SetTileNotificationClick(object sender, RoutedEventArgs e)
        {
            if (IsRunningAsUwp())
            {
                SetTileNotification(txtTileMessage.Text);
                MessageBox.Show("Tile message updated!");
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

        // Make sure you already pinned the app in start menu of your Windows 10. And resize the notification as Wide
        public void SetTileNotification(string message)
        {
            var template = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text01);
            var childNode = template?.GetElementsByTagName("text");
            childNode[0].InnerText = message;
            TileNotification tileNotification = new TileNotification(template);
            TileUpdater updateMgr = TileUpdateManager.CreateTileUpdaterForApplication();
            updateMgr.Update(tileNotification);
        }
    }
}
