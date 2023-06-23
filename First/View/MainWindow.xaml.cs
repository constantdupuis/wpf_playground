using First.StartupHelpers;
using First.View;
using System.Windows;
using WpfLibrary;

namespace First
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataAccess _dataAccess;
        private readonly IAbstractFactory<ChildForm> _childFormFactory;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> childFormFactory)
        {
            InitializeComponent();
            this._dataAccess = dataAccess;
            this._childFormFactory = childFormFactory;
        }

        private void getData_Click(object sender, RoutedEventArgs e)
        {
            data.Text = _dataAccess.GetData();
        }

        private void openChildForm_Click(object sender, RoutedEventArgs e)
        {
            _childFormFactory.Create().Show();
        }
    }
}