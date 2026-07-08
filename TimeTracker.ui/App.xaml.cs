using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace TimeTracker.ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public static IHost Host { get; private set; }
        public App()
        {
            //the following is already included in the .CreateDefaultBuilder()
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            Host = Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //Register Classes and Services
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<MainWindow>();
                }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

    }

}
