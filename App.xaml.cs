using CRMGuru.TestTask.WebApiClient;
using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Services;
using CRMGuru.TestTaskWpf.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CRMGuru.TestTaskWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static IHost _hosting;
        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        
        public static IServiceProvider Services => Hosting.Services;

        private static IHostBuilder CreateHostBuilder(string[] Args) => Host
            .CreateDefaultBuilder(Args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDbContext<EfDataContext>(options => options.UseSqlServer(
                host.Configuration.GetConnectionString("DefaultConnection")));
           
            services.AddScoped<MainWindowViewModel>();
            services.AddSingleton<NavigationService>();
            services.AddHttpClient<IWebServices, WebServices>(client => client.BaseAddress = new Uri(host.Configuration["RestCountries"]));

            //services.AddScoped<IAddCountryService, AddCountryService>();
            //services.AddScoped<ILoadContryService, LoadContryService>();

            
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Hosting;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(true);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Hosting;
            base.OnExit(e);
            await host.StopAsync().ConfigureAwait(false);
        }
    }
}
