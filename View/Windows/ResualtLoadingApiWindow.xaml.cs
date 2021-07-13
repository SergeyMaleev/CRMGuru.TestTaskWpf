using CRMGuru.TestTaskWpf.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRMGuru.TestTaskWpf.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ResualtLoadingApiWindow.xaml
    /// </summary>
    public partial class ResualtLoadingApiWindow : Window
    {
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(
              nameof(CountryModel),
              typeof(RestСountry),
              typeof(ResualtLoadingApiWindow),
              new PropertyMetadata(null));

        public RestСountry CountryModel
        {
            get => (RestСountry)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        public ResualtLoadingApiWindow() => InitializeComponent();

        private void Save_Click(object sender, RoutedEventArgs e) => this.DialogResult = true;
        private void Сancel_Click(object sender, RoutedEventArgs e) => this.DialogResult = false;
    }
}
