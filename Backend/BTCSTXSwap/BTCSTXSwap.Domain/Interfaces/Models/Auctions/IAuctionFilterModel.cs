using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Auctions
{
    public interface IAuctionFilterModel
    {
        RarityEnum? Rarity { get; set; }
        int? StrengthStart { get; set; }
        int? StrengthEnd { get; set; }
        int? AgilityStart { get; set; }
        int? AgilityEnd { get; set; }
        int? VigorStart { get; set; }
        int? VigorEnd { get; set; }
        int? IntelligenceStart { get; set; }
        int? IntelligenceEnd { get; set; }
        int? PerceptionStart { get; set; }
        int? PerceptionEnd { get; set; }
        int? CharismStart { get; set; }
        int? CharismEnd { get; set; }
        GenreEnum? Genre { get; set; }
        RaceEnum? Race { get; set; }
        RaceEnum? Hair { get; set; }
        RaceEnum? Ear { get; set; }
        RaceEnum? Eye { get; set; }
        RaceEnum? Mount { get; set; }
        RaceEnum? Skin { get; set; }
        int? Page { get; set; }
    }
}
