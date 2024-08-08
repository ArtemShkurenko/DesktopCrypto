using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Crypto.Models;
using Newtonsoft.Json;

namespace Crypto.Core
{
    public class ApiService
    {
        private readonly HttpClient client = new HttpClient();
        public ApiService()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "DesktopCryptoApp/1.0");
        }
        public async Task<List<Currency>> GetTopCurrenciesAsync()
        {
            string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                try
                {
                    var currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
                    return currencies;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Reason Phrase: {response.ReasonPhrase}");
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            return new List<Currency>();
        }
    }
}
