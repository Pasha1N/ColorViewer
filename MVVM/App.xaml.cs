using MVVM.ViewModels;
using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            MainWindow window = new MainWindow(mainWindowViewModel);
            window.Show();
        }

    }
}
