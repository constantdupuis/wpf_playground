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
using System.Windows.Shapes;
using WpfLibrary;

namespace First.View
{
    /// <summary>
    /// Interaction logic for ChildForm.xaml
    /// </summary>
    public partial class ChildForm : Window
    {
        private readonly IDataAccess _dataAccess;

        public ChildForm(IDataAccess dataAccess)
        {
            InitializeComponent();
            this._dataAccess = dataAccess;
            dataAccessInfo.Text = this._dataAccess.GetData();
        }
    }
}
