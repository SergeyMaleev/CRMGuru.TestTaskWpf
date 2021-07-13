using CRMGuru.TestTaskWpf.ViewModels;

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
