using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace First.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> availableCOMPorts { get; set; } = new ObservableCollection<string>();

        public MainWindowViewModel()
        {
            GetAvailableCOMPorts();
        }

        public void GetAvailableCOMPorts()
        {
            availableCOMPorts.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                availableCOMPorts.Add(port);
            }
        }
    }
}
