using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Crypto.Models;
using Newtonsoft.Json;

namespace Crypto.DAL
{
    public class InMemoryRepository
    {
        private List<Currency> _currencies;

        public InMemoryRepository()
        {
            LoadData();
        }
        private void LoadData()
        {
            if (File.Exists("data.json"))
            {
                string json = File.ReadAllText("data.json");
                _currencies = JsonConvert.DeserializeObject<List<Currency>>(json) ?? new List<Currency>();
            }
            else
            {
                _currencies = new List<Currency>();
            }
        }
        public async Task<List<Currency>> GetTopCurrenciesAsync()
        {
            await Task.Delay(100);
            return _currencies;
        }
        public async Task SaveDataAsync(List<Currency> currencies)
        {
            _currencies = currencies;
            string json = JsonConvert.SerializeObject(currencies, Formatting.Indented);
            await File.WriteAllTextAsync("data.json", json);
        }
    }
}
