using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using GdutApp.ViewModel;

internal class ViewModelLocator
{
    public ViewModelLocator()
    {
        ConfigureServices();
    }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Services
        // services.AddSingleton<IContactsService, ContactsService>();
        // services.AddSingleton<IPhoneService, PhoneService>();

        // Viewmodels
        services.AddTransient<MainWindowVM>();

        var serviceProvider = services.BuildServiceProvider();
        Ioc.Default.ConfigureServices(serviceProvider);

        return serviceProvider;
    }

    public MainViewModel? MainVM { get { return Ioc.Default.GetService<MainViewModel>(); } }

}

namespace GdutApp
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Toolkit.Mvvm.DependencyInjection;
    using System;

    internal class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ConfigureServices();
        }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Services
            // services.AddSingleton<IContactsService, ContactsService>();
            // services.AddSingleton<IPhoneService, PhoneService>();

            // Viewmodels
            services.AddTransient<MainViewModel>();

            var serviceProvider = services.BuildServiceProvider();
            Ioc.Default.ConfigureServices(serviceProvider);

            return serviceProvider;
        }

        public MainViewModel? MainVM { get { return Ioc.Default.GetService<MainViewModel>(); } }

    }
}
