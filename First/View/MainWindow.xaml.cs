using First.StartupHelpers;
using First.View;
using First.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        private readonly IServiceProvider _services;
        private readonly MainWindowViewModel _vm;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> childFormFactory, IServiceProvider services, MainWindowViewModel vm)
        {
            InitializeComponent();
            this._dataAccess = dataAccess;
            this._childFormFactory = childFormFactory;
            this._services = services;
            this._vm = vm;
            DataContext = this._vm;
        }

        private void getData_Click(object sender, RoutedEventArgs e)
        {
            data.Text = _dataAccess.GetData();
        }

        private void openChildForm_Click(object sender, RoutedEventArgs e)
        {
            _childFormFactory.Create().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _services.GetRequiredService<ConnectWindow>().Show();
        }
    }
}