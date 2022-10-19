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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceSerial arduinoPort;
        public MainWindow()
        {
            InitializeComponent();
            arduinoPort = new DeviceSerial();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            arduinoPort.Connect(3);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            arduinoPort.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
