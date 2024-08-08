using Newtonsoft.Json;

namespace Crypto.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } 

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        public int MarketCapRank { get; set; }
        public decimal? FullyDilutedValuation { get; set; }

        [JsonProperty("total_volume")]
        public decimal TotalVolume { get; set; }
        public decimal High24h { get; set; }
        public decimal Low24h { get; set; }
        public decimal PriceChange24h { get; set; }
        public decimal PriceChangePercentage24h { get; set; }
        public decimal MarketCapChange24h { get; set; }
        public decimal MarketCapChangePercentage24h { get; set; }
        public decimal CirculatingSupply { get; set; }
        public decimal TotalSupply { get; set; }
        public decimal? MaxSupply { get; set; }
        public decimal Ath { get; set; }
        public decimal AthChangePercentage { get; set; }
        public string AthDate { get; set; }
        public decimal Atl { get; set; }
        public decimal AtlChangePercentage { get; set; }
        public string AtlDate { get; set; }
        public Roi Roi { get; set; }
        public string LastUpdated { get; set; }
    }
}
