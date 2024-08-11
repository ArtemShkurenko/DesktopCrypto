using DesktopCrypto.Views;
using System.Windows;

namespace DesktopCrypto
{
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (ViewModel)DataContext;
        }
        private async void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.SaveDataAsync();
        }
        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var currencies = _viewModel.Currencies;
            DetailPage detailPage = new DetailPage(currencies);
            detailPage.ShowDialog();
        }
    }
}
