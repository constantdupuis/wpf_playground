using First.View;
using First.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Ports;
using WpfLibrary;

namespace First.StartupHelpers;

public static class ServiceExtentions
{
    public static void AddFormFactory<TForm>(this IServiceCollection services) 
        where TForm : class
    { 
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>( x => () => x.GetService<TForm>()!);
        services.AddSingleton<IAbstractFactory<TForm>,AbstractFactory<TForm>>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<ConnectWindow>();
        services.AddSingleton<ConnectWindowViewModel>();
        services.AddFormFactory<ChildForm>();
        services.AddTransient<IDataAccess, DataAccess>();
    }
}