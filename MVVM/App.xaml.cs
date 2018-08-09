using ColorViewer.Models;
using ColorViewer.ViewModels;
using ColorViewer.Views;
using System.Windows;

namespace ColorViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ColorManager colorManager = new ColorManager();
            ViewModelFactory viewModelFactory = new ViewModelFactory(colorManager);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(colorManager, viewModelFactory);
            MainWindow window = new MainWindow(mainWindowViewModel);
            window.Show();
        }
    }
}