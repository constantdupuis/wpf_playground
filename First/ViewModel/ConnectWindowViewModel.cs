using First.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.ViewModel
{
    public class ConnectWindowViewModel : ViewModelBase
    {
        public ConnectCommand ConnectCmd { get; set; }
        private const int defaultSpeedIndex = 3;
        private string[] availablesSpeeds = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" }; 
        public ObservableCollection<string> AvailableCOMPorts { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> AvailableCOMSpeeds { get; set; } = new ObservableCollection<string>();

        public bool CanConnect { get; set; } = false;

        private string _selectedComPort;
        public string SelectedCOMPort
        {
            get { return _selectedComPort; }
            set {
                if(_selectedComPort != value)
                {
                    _selectedComPort = value;
                    OnPropertyChanged(nameof(SelectedCOMPort));
                }
                 
            }
        }

        private string _selectedSpeed;
        public string SelectedSpeed
        {
            get { return _selectedSpeed; }
            set { 
                if(  _selectedSpeed != value)
                {
                    _selectedSpeed = value;
                    OnPropertyChanged(nameof(SelectedSpeed));
                }
            }
        }


        public ConnectWindowViewModel()
        {
            GetAvailableCOMPorts();
            SetAvailableSpeeds();
            ConnectCmd = new ConnectCommand(this);
        }

        private void SetAvailableSpeeds()
        {
            foreach (var speed in availablesSpeeds)
            {
                AvailableCOMSpeeds.Add(speed);
            }
            // Make sure we don't provide an out of range default speed index
            if (defaultSpeedIndex < availablesSpeeds.Length)
            {
                SelectedSpeed = availablesSpeeds[defaultSpeedIndex];
            }
            else {
                throw new IndexOutOfRangeException("Default speed index out of range!");
            }
        }

        public void GetAvailableCOMPorts()
        {
            AvailableCOMPorts.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                AvailableCOMPorts.Add(port);
            }

            SelectedCOMPort = "";
            if (ports.Length > 0)
            {
                SelectedCOMPort = ports[0];
                CanConnect = true;
            }
        }
    }
}
