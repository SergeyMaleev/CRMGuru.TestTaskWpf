using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using CRMGuru.TestTaskWpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTaskWpf
{
    internal class ServiceLocator
    {        
        public MainWindowViewModel MainModel => App.Resolve<MainWindowViewModel>(); 
        public StartUserControlViewModel StartModel => App.Resolve<StartUserControlViewModel>();
        public CountryLoadingApiUserControlViewModel LoadingApiModel => App.Resolve<CountryLoadingApiUserControlViewModel>();
        public CountriesLoadingDBUserControlViewModel LoadingDBModel => App.Resolve<CountriesLoadingDBUserControlViewModel>();        
    }
}
