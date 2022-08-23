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
using CloudKitSharp.Core.Http;

namespace CloudKitSharp.SampleWPF
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var ckClient = new CKClient(
                "iCloud.jp.pocosoft.CloudKitSharp",
                "70b43599849b12f90464938ed1aed59b999c2ee18e9cd3936a18e15b49f584d8",
                "b2eb419a4ab40758d32657a0d07cf84d44553891590095b9d89fa674d9b8a650"
                );
            var response = await ckClient.GetUsersCaller(null);
            DebugConsole.Text = response.Content;
        }
    }
}
