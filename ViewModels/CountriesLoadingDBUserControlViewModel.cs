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
using System.Threading;
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
        private int _currentProgress;
        private bool _loadingStatus;
        private CancellationTokenSource _cts;

        /// <summary>
        /// Коллекция стран
        /// </summary>
        public IEnumerable<Country> Countries
        {
            get => _countries;
            set => Set(ref _countries, value);
        }

        /// <summary>
        /// Статус показа полосы загрузки
        /// </summary>
        public bool LoadingStatus
        {
            get => _loadingStatus;
            set => Set(ref _loadingStatus, value);
        }

        /// <summary>
        /// Служит для анимации загрузочной строки
        /// </summary>
        public int CurrentProgress
        {
            get => _currentProgress;
            set => Set(ref _currentProgress, value);
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
            _cts = new CancellationTokenSource();
            Task Loader = new Task(ProgressBar, _cts.Token);
            Loader.Start();

            try
            {
                await Task.Run(() => _countries = _dbServices.GetAll());
                _cts.Cancel();
                OnPropertyChanged("Countries");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка выполнения операции {e.Message}");
            }
        }

        /// <summary>
        /// вспомогательный метод который меняет прогресс бар 
        /// </summary>        
        private void ProgressBar()
        {
            LoadingStatus = true;
            OnPropertyChanged("LoadingStatus");

            for (int i = _currentProgress; i < 100; i++)
            {
                if (_cts.IsCancellationRequested)
                {
                    LoadingStatus = false;
                    _currentProgress = 0;
                    return;
                }
                _currentProgress++;
                Thread.Sleep(50);
                OnPropertyChanged("CurrentProgress");
            }
        }
    }
}
