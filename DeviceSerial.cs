using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    class DeviceSerial : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }

        SerialPort serialPort = new SerialPort();

        public string ReceiveData { get; set; }

        public DeviceSerial()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 1, 2, 3, 4, 5 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }
                }
            };

            DataContext = this;
        }

        public static double[] Plot_Y_Data = new double[160];

        public bool Connect(int portName, int baudRate = (int)9600, int DateBits = (int)8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
        {
            if (serialPort.IsOpen == false)
            {
                serialPort.PortName = "COM" + portName.ToString();
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.StopBits = stopBits;
                serialPort.DataBits = DateBits;

                serialPort.Open();

                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceiveHandler);
                //                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceiveHandler2);
            }

            return true;
        }

        private void DataReceiveHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            ReceiveData = serialPort.ReadExisting();
        }

        public bool Close()
        {
            serialPort.Close();

            return true;
        }
    }
}