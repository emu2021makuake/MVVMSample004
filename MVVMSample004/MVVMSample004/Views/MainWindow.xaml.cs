using MVVMSample004.ViewModels;
using System.Windows;

namespace MVVMSample004.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
