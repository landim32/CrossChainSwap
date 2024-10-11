using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Auctions
{
    public class AuctionFilterModel: IAuctionFilterModel
    {
        public RarityEnum? Rarity { get; set; }
        public int? StrengthStart { get; set; }
        public int? StrengthEnd { get; set; }
        public int? AgilityStart { get; set; }
        public int? AgilityEnd { get; set; }
        public int? VigorStart { get; set; }
        public int? VigorEnd { get; set; }
        public int? IntelligenceStart { get; set; }
        public int? IntelligenceEnd { get; set; }
        public int? PerceptionStart { get; set; }
        public int? PerceptionEnd { get; set; }
        public int? CharismStart { get; set; }
        public int? CharismEnd { get; set; }
        public GenreEnum? Genre { get; set; }
        public RaceEnum? Race { get; set; }
        public RaceEnum? Hair { get; set; }
        public RaceEnum? Ear { get; set; }
        public RaceEnum? Eye { get; set; }
        public RaceEnum? Mount { get; set; }
        public RaceEnum? Skin { get; set; }
        public int? Page { get; set; }
    }
}
