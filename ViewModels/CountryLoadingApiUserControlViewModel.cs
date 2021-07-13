using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Models;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using CRMGuru.TestTaskWpf.View.UserControls;
using CRMGuru.TestTaskWpf.View.Windows;
using CRMGuru.TestTaskWpf.ViewModels.Base;
using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace CRMGuru.TestTaskWpf.ViewModels
{
    internal class CountryLoadingApiUserControlViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly IWebService _webServices;     
        private readonly IDbService _dbServices;
        private RestСountry _country;
        private string _inputContryName;
        private int _currentProgress = 0;
        private bool _loadingStatus = false;
        /// <summary>
        /// Поле ввода страны пользователем
        /// </summary>
        public string InputContryName
        {
            get => _inputContryName;
            set => Set(ref _inputContryName, value);
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

        public RestСountry Country
        {
            get => _country;
            set => Set(ref _country, value);
        }

        public CountryLoadingApiUserControlViewModel(NavigationService navigation, IWebService webServices, IDbService dbServices)
        {              
            _navigation = navigation;
            _dbServices = dbServices;
            _webServices = webServices;
        }

        public ICommand DouwnCommand => new DelegateCommand(() =>
        {
            _navigation.Navigate(new StartUserControl());
        });

        public ICommand CountryLoadingApiCommand => new DelegateCommand( async () =>
        {           
            try
            {
                var resultСountries = await _webServices.GetArrayAsync(InputContryName);
                Country = resultСountries.First();
                var loadingApiWindow = new ResualtLoadingApiWindow { CountryModel = Country };
                loadingApiWindow.ShowDialog();

                if (loadingApiWindow.DialogResult == true)
                {
                   
                    await _dbServices.Add(new Country {
                    Name = Country.Name,
                    CountryCode = Country.Alpha3Code,
                    Area = Country.Area,
                    Population = Country.Population,
                    Region = new Region { Name = Country.Region},
                    Сapital = new City { Name = Country.Capital}
                    });
                    loadingApiWindow.Close();

                    MessageBox.Show("Успешно добавлено");
                }
                else
                {
                    loadingApiWindow.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка выполнения операции {e.Message}");
            }
        }, () => !String.IsNullOrEmpty(InputContryName));
   
    }
}
