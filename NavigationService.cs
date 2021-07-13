using CRMGuru.TestTaskWpf.Services.Interrfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CRMGuru.TestTaskWpf
{
    public class NavigationService
    {
     
        public event Action<UserControl> OnPageChanged;

        public void Navigate(UserControl userControl)
        {           
            OnPageChanged?.Invoke(userControl);
        }
    }
}
