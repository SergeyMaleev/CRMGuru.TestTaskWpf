using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Models;
using CRMGuru.TestTaskWpf.Services;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using CRMGuru.TestTaskWpf.View.UserControls;
using CRMGuru.TestTaskWpf.ViewModels.Base;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRMGuru.TestTaskWpf.ViewModels
{
    public class CountriesLoadingDBUserControlViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly IDbService _dbServices;
        private IEnumerable<Country> _countries;

        /// <summary>
        /// Коллекция стран
        /// </summary>
        public IEnumerable<Country> Countries
        {
            get => _countries;
            set => Set(ref _countries, value);
        }

        public CountriesLoadingDBUserControlViewModel(NavigationService navigation, IDbService dbServices)
        {
            _navigation = navigation;
            _dbServices = dbServices;
            LoagingCountries();
        }

        public ICommand DouwnCommand => new DelegateCommand(() =>
        {
            _navigation.Navigate(new StartUserControl());
        });


        public async Task LoagingCountries()
        {
            try
            {
                await Task.Run(() => _countries = _dbServices.GetAll());
                OnPropertyChanged("Countries");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка выполнения операции {e.Message}");
            }
        }
    }
}
