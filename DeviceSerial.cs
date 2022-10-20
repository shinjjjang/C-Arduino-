using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class DeviceSerial
    {
        SerialPort serialPort = new SerialPort();
        public string receiveData = "";

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
            SerialPort serialPort = (SerialPort) sender;
            receiveData = serialPort.ReadExisting();
        }

        public bool Close()
        {
            serialPort.Close();
            
            return true;
        }
    }
}
