using System;
using System.Windows.Controls;

namespace CRMGuru.TestTaskWpf
{
    internal class NavigationService
    {    
        public event Action<UserControl> OnPageChanged;
        public void Navigate(UserControl userControl) => OnPageChanged?.Invoke(userControl);      
    }
}
