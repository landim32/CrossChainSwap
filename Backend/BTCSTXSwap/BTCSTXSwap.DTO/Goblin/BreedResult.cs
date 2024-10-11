using BTCSTXSwap.DTO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Goblin
{
    public class BreedResult : StatusResult
    {
        [JsonPropertyName("breedCost")]
        public decimal BreedCost { get; set; }
        [JsonPropertyName("breedRarity")]
        public int BreedRarity { get; set; }
    }
}
