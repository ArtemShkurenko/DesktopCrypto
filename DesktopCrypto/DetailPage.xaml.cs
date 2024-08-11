using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Crypto.Models;
using Crypto.Core;

namespace DesktopCrypto.Views
{
    public partial class DetailPage : Window, INotifyPropertyChanged
    {
        private readonly CurrencyService _currencyService;

        public DetailPage(ObservableCollection<Currency> currencies)
        {
            InitializeComponent();
            _currencyService = new CurrencyService(currencies.ToList());
            Currencies = currencies;
            DataContext = this;
        }
        public ObservableCollection<Currency> Currencies { get; set; }
        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged();
            }
        }
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        private Currency _selectedCurrencyToConvertFrom;
        public Currency SelectedCurrencyToConvertFrom
        {
            get => _selectedCurrencyToConvertFrom;
            set
            {
                _selectedCurrencyToConvertFrom = value;
                OnPropertyChanged();
            }
        }
        private Currency _selectedCurrencyToConvertTo;
        public Currency SelectedCurrencyToConvertTo
        {
            get => _selectedCurrencyToConvertTo;
            set
            {
                _selectedCurrencyToConvertTo = value;
                OnPropertyChanged();
            }
        }
        private decimal _amountToConvert;
        public decimal AmountToConvert
        {
            get => _amountToConvert;
            set
            {
                _amountToConvert = value;
                OnPropertyChanged();
            }
        }
        private decimal _convertedAmount;
        public decimal ConvertedAmount
        {
            get => _convertedAmount;
            set
            {
                _convertedAmount = value;
                OnPropertyChanged();
            }
        }
        private async void SearchCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            var currency = await _currencyService.SearchCurrencyAsync(SearchQuery);
            SelectedCurrency = currency;
            if (currency != null && !Currencies.Contains(currency))
            {
                Currencies.Add(currency);
            }
        }
        private async void ConvertCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCurrencyToConvertFrom != null && SelectedCurrencyToConvertTo != null && AmountToConvert > 0)
            {
                ConvertedAmount = await _currencyService.ConvertCurrencyAsync(SelectedCurrencyToConvertFrom.Symbol, SelectedCurrencyToConvertTo.Symbol, AmountToConvert);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}