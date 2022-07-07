using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using CommunityToolkit.Mvvm.DependencyInjection;
using GdutApp.IWebApi;
using GdutApp.View;
using GdutApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace GdutApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
{

        public static IHost? Host { get; private set; }
        public App()
        {
            //Ioc.Default.ConfigureServices(new ServiceCollection().AddSingleton<IFoo, Foo>().BuildServiceProvider());
            // Text1 =Ioc.Default.GetService<IFoo>().GetText();

            //Ioc.Default.ConfigureServices(
            //    new ServiceCollection()
            //    .AddSingleton<IDialogService, DialogService>() //Services
            //    .BuildServiceProvider());


            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);

                })
                .ConfigureLogging((context, logging) =>
                {
                    //logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    //logging.AddDebug();
                    //logging.AddNLog();
                })
                .Build();

        }
        private void ConfigureServices(IServiceCollection services)
        {
            // Add Services
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ServerStatusView>();
            services.AddSingleton<MainWindowVM>();
            services.AddSingleton(RestService.For<ILocalJson>(AppDomain.CurrentDomain.BaseDirectory));

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host!.StartAsync();
            //此处也可以在xaml中配置
            var window = Host.Services.GetRequiredService<ServerStatusView>();
            window.DataContext = Host.Services.GetRequiredService<MainWindowVM>();
            window.Show();
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await Host!.StopAsync();
            base.OnExit(e);
        }
    }
}
