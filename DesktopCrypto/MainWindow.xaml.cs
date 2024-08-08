using System.Windows;

namespace DesktopCrypto
{
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            // DataContext = new ViewModel();
            _viewModel = (ViewModel)DataContext;
            //MainFrame.Navigate(new MainView());

        }
        private async void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.SaveDataAsync();
        }

    }
}
