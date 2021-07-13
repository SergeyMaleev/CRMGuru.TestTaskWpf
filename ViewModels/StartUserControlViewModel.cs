using CRMGuru.TestTaskWpf.View.UserControls;
using CRMGuru.TestTaskWpf.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace CRMGuru.TestTaskWpf.ViewModels
{
    internal class StartUserControlViewModel : ViewModel
    {
        private readonly NavigationService _navigation;

        public StartUserControlViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }
      
        public ICommand CountriesLoadingDBCommand => new DelegateCommand(() =>
        {
            _navigation.Navigate(new CountriesLoadingDBUserControl());
        });

        public ICommand CountryLoadingApiCommand => new DelegateCommand(() =>
        {
            _navigation.Navigate(new CountryLoadingApiUserControl());
        });
    }
}
