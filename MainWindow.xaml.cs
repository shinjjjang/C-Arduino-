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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceSerial arduinoSerial;

        DispatcherTimer dispatcher = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            arduinoSerial = new DeviceSerial();
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcher.Start();
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            textBox1.Text = arduinoSerial.ReceiveData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            arduinoSerial.Connect(3);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            arduinoSerial.Close();
            dispatcher.Stop();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}