using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Navigation;

namespace First
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, serviceq) => {

                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();

            startupForm.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {

            base.OnExit(e);
        }
    }
}