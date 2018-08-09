using ColorViewer.ViewModels;
using System.Windows;

namespace ColorViewer.Views
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel; 
        }
    }
}