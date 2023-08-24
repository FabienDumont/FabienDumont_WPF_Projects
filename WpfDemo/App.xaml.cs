using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using WpfDemo.MVVM.ViewModels;
using WpfDemo.MVVM.Views;

namespace WpfDemo; 

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App {
	private readonly IHost _host;
	
	public App() {
        _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(
            c => {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            }
        ).ConfigureServices(
            (_, services) => {
                // Store classes to send information through ViewModels
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();

                services.AddSingleton<StringStore>();

                services.AddSingleton<CloseModalNavigationService>();

                // Services creation to allow ViewModels to navigate from one to another

                services.AddTransient<HomeVm>(
                    s => new HomeVm(s.GetRequiredService<StringStore>(), CreateInformationNavigationService(s))
                );

                services.AddSingleton(s =>
                    new NavigationService<HomeVm>(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<HomeVm>));

                services.AddTransient(
                    s => new LoadingSpinnerDemoVm(s.GetRequiredService<StringStore>(), s.GetRequiredService<CloseModalNavigationService>()));


                // Nav Bar
                services.AddTransient(s => new NavigationBarVm());

                // Creation of the Main Window which can display the User Controls
                services.AddSingleton<MainVm>();
                services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainVm>() });
            }
        ).Build();
    }
    
    protected override void OnStartup(StartupEventArgs e) {
        _host.Start();

        INavigationService mainNavigationService = _host.Services.GetRequiredService<NavigationService<HomeVm>>();
        mainNavigationService.Navigate();

        // Showing the main Window
        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }
    
    protected override async void OnExit(ExitEventArgs e) {
        await _host.StopAsync();
        _host.Dispose();
    }
    
    private static INavigationService CreateInformationNavigationService(IServiceProvider serviceProvider) {
        return new ModalNavigationService<LoadingSpinnerDemoVm>(
            serviceProvider.GetRequiredService<ModalNavigationStore>(), serviceProvider.GetRequiredService<LoadingSpinnerDemoVm>
        );
    }
    
}