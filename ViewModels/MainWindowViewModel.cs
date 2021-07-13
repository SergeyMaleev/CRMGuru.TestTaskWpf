using CRMGuru.TestTaskWpf.View.UserControls;
using CRMGuru.TestTaskWpf.ViewModels.Base;
using System.Windows.Controls;

namespace CRMGuru.TestTaskWpf.ViewModels
{
    /// <summary>
    /// Модель представления главного окна
    /// </summary>
    internal class MainWindowViewModel : ViewModel
    {
        public string Title { get; set; } = "Тестовое задание для CRMGuru";

        private UserControl _userControl;

        public UserControl CurrenUserControl
        {
            get => _userControl;
            set => Set(ref _userControl, value);
        }

        public MainWindowViewModel(NavigationService navigation)
        {            
            navigation.OnPageChanged += userControl => CurrenUserControl = userControl; //подписываемся на навигацию для пооказа текущей страницы           
            navigation.Navigate(new StartUserControl()); //первая страница, страница входа            
        }
    }
}
