using System;
using System.Web;
using System.Windows;

namespace CloudKitSharp.SampleWPF
{
    /// <summary>
    /// WebViewWinow.xaml の相互作用ロジック
    /// </summary>
    public partial class WebViewWinow : Window
    {
        public Action<string> GetWebAuthTokenDelegate;
        public Uri Source;
        public WebViewWinow(Uri source)
        {
            InitializeComponent();
            Source = source;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebView.Source = Source;
        }

        private void WebView_NavigationStarting(
            object sender,
            Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri.StartsWith("http://localhost"))
            {
                var uri = new Uri(e.Uri);
                var query = HttpUtility.ParseQueryString(uri.Query);
                var webAuthToken = query.Get("ckWebAuthToken");
                if (webAuthToken != null)
                {
                    GetWebAuthTokenDelegate(webAuthToken);
                    Close();
                }
            }
        }
    }
}
