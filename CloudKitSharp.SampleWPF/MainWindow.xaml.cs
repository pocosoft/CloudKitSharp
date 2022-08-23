using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using CloudKitSharp.Core.Http;

namespace CloudKitSharp.SampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _webAuthToken
        {
            get
            {
                return Settings.Default.WebAuthToken;
            }
            set
            {
                Settings.Default.WebAuthToken = value;
                Settings.Default.Save();
            }
        }
        private static string privateKeyString
        {
            get
            {
                var key = "";
                var assembly = Assembly.GetExecutingAssembly();
                foreach (var name in assembly.GetManifestResourceNames())
                {
                    Debug.Print(name);
                    if (name.EndsWith("eckey.pem"))
                    {
                        var stream = assembly.GetManifestResourceStream(name);
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            key = sr.ReadToEnd();
                            sr.Close();
                        }
                    }
                }
                return key;
            }
        }
        private static readonly CKClient _client = new CKClient(
                "iCloud.jp.pocosoft.CloudKitSharp",
                "70b43599849b12f90464938ed1aed59b999c2ee18e9cd3936a18e15b49f584d8",
                "b2eb419a4ab40758d32657a0d07cf84d44553891590095b9d89fa674d9b8a650",
                privateKeyString
            );
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetWebAuthToken(_webAuthToken);
        }
        private async void GetUserDiscoverButton_Click(object sender, RoutedEventArgs e)
        {
            var response = await _client.GetUsersDiscover(_webAuthToken);
            DebugConsole.Text = response.Content;
        }
        private void GetWebAuthToken(string webAuthToken)
        {
            Debug.Print(webAuthToken);
            _webAuthToken = webAuthToken;
            GetUserCaller(_webAuthToken);
        }

        private async void GetUserCaller(string? webAuthToken)
        {
            var response = await _client.GetUsersCaller(webAuthToken);
            DebugConsole.Text = response.Content;

            if (!response.IsSuccessful && response.Content != null)
            {
                CKError error = CKError.Parse(response.Content);
                Debug.Print(error.RedirectURL);
                var web = new WebViewWinow(new Uri(error.RedirectURL));
                web.GetWebAuthTokenDelegate += GetWebAuthToken;
                web.ShowDialog();
            }
        }
    }
}
