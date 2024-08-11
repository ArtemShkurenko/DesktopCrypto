using System;
using Crypto.Models;

namespace Crypto.Core
{
    public class CurrencyService
    {
        private readonly List<Currency> _currencies;

        public CurrencyService(List<Currency> currencies)
        {
            _currencies = currencies;
        }
        public Task<Currency> SearchCurrencyAsync(string query)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return null;
                }
                var normalizedQuery = query.Trim().ToLower();
                return _currencies.FirstOrDefault(c =>
                    c.Symbol.ToLower() == normalizedQuery ||
                    c.Name.ToLower().Contains(normalizedQuery));
            });
        }
        public Task<decimal> ConvertCurrencyAsync(string fromCurrencySymbol, string toCurrencySymbol, decimal amount)
        {
            return Task.Run(() =>
            {
                var fromCurrency = _currencies.FirstOrDefault(c => c.Symbol.Equals(fromCurrencySymbol, StringComparison.OrdinalIgnoreCase));
                var toCurrency = _currencies.FirstOrDefault(c => c.Symbol.Equals(toCurrencySymbol, StringComparison.OrdinalIgnoreCase));

                if (fromCurrency == null || toCurrency == null || amount <= 0)
                {
                    return 0m;
                }

                decimal conversionRate = fromCurrency.CurrentPrice / toCurrency.CurrentPrice;
                decimal convertedAmount = (decimal)amount * conversionRate;

                return convertedAmount;
            });
        }
    }
}