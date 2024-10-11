using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinBreedService
    {
        GoblinListResult ListGoblinCanBreed(long tokenId, int cursorGob);
        decimal GetBreedCost(long tokenId1, long tokenId2);
        GoboxEnum GetBreedRarity(long tokenId1, long tokenId2);
        long Breed(long idUser, long tokenId1, long tokenId2);
        decimal GetFusionCost(long tokenId);
        long Fusion(long idUser, long tokenId1, long tokenId2);
        IGoblinModel GenerateRandom(long idUser, int rarity);
    }
}
