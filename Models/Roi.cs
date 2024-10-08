﻿using Newtonsoft.Json;

namespace Crypto.Models
{
    public class Roi
    {
        [JsonProperty("times")]
        public decimal Times { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("percentage")]
        public decimal Percentage { get; set; }
    }
}
