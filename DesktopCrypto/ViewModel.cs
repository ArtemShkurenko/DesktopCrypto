using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Crypto.Core;
using Crypto.DAL;
using Crypto.Models;

namespace DesktopCrypto
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Currency> _currencies;
        private readonly ApiService _apiService;
        private readonly InMemoryRepository _repository;

        public ObservableCollection<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }
        public ViewModel()
        {
            _apiService = new ApiService();
            _repository = new InMemoryRepository();
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            var currencies = await _apiService.GetTopCurrenciesAsync();
            Currencies = new ObservableCollection<Currency>(currencies);
        }
        public async Task SaveDataAsync()
        {
            var currencies = new List<Currency>(Currencies);
            await _repository.SaveDataAsync(currencies);
            MessageBox.Show("Data saved successfully");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

