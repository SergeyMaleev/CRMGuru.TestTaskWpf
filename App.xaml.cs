using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Services;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using CRMGuru.TestTaskWpf.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CRMGuru.TestTaskWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : IDesignTimeDbContextFactory<EfDataContext>
    {
        private static readonly ServiceProvider _provider;

        public static IConfiguration Configuration { get; private set; }

        static App ()
        {
            var services = new ServiceCollection();

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = config.Build();

            services.AddDbContext<EfDataContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDbService, DbServices>();

            services.AddScoped<StartUserControlViewModel>();
            services.AddScoped<MainWindowViewModel>();
            services.AddTransient<CountriesLoadingDBUserControlViewModel>();
            services.AddTransient<CountryLoadingApiUserControlViewModel>();
            services.AddHttpClient<IWebService, WebServices>(client => client.BaseAddress = new Uri(Configuration["RestCountries"]));
            services.AddSingleton<NavigationService>();

            _provider = services.BuildServiceProvider();
        }
        
        public static T Resolve<T>() => _provider.GetRequiredService<T>();

        public EfDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfDataContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new EfDataContext(optionsBuilder.Options);
        }
    }
}
