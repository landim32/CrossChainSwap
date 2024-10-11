using System;
using System.Drawing;
using System.Numerics;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGeneService
    {
        GeneInfo ConvertInt256ToGene(BigInteger code);
        BigInteger ConvertGeneToInt256(GeneInfo gene);
        int GetRarityByBox(GoboxEnum gobox);
        //int GetRarity(int rarity1, int rarity2);
        GoboxEnum GetBoxByBreed(RarityEnum goblin1, RarityEnum goblin2);
        Color MixColor(Color c1, Color c2);
        GeneInfo MixGenes(GeneInfo male, GeneInfo female);
    }
}
