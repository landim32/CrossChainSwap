using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Core.Domain;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GeneService : IGeneService
    {
        private const byte FOREST = 0x31;
        private const byte DESERT = 0x32;
        private const byte CAVE = 0x33;
        private const byte MOUNTAIN = 0x34;
        private const byte DARK = 0x35;
        private const byte SEA = 0x36;

        private const byte MALE = 0x6d;
        private const byte FEMALE = 0x66;

        private const int SKIN = 1;
        private const int HAIR = 4;
        private const int EYES = 7;
        private const int EAR = 10;
        private const int MOUTH = 13;
        private const int COLORSKIN = 16;
        private const int COLORHAIR = 19;
        private const int COLOREYES = 22;
        private const int RACE = 25;
        private const int RARITY = 26;

        private Random _rand = new Random();

        private GenreEnum ByteToGenre(byte b)
        {
            switch (b)
            {
                case MALE:
                    return GenreEnum.Male;
                case FEMALE:
                    return GenreEnum.Female;
                default:
                    return GenreEnum.Male;
                    //throw new Exception(string.Format("'{0}' is not a valid Genre.", b));
            }
        }

        private byte GenreToByte(GenreEnum g)
        {
            switch (g)
            {
                case GenreEnum.Male:
                    return MALE;
                case GenreEnum.Female:
                    return FEMALE;
                default:
                    throw new Exception(string.Format("'{0}' is not a valid Genre.", g));
            }
        }

        private RaceEnum ByteToRace(byte b)
        {
            switch (b)
            {
                case FOREST:
                    return RaceEnum.Forest;
                case DESERT:
                    return RaceEnum.Desert;
                case CAVE:
                    return RaceEnum.Cave;
                case MOUNTAIN:
                    return RaceEnum.Mountain;
                case DARK:
                    return RaceEnum.Dark;
                case SEA:
                    return RaceEnum.Sea;
                default:
                    throw new Exception(string.Format("'{0}' is not a valid race.", b));
            }
        }

        private byte RaceToByte(RaceEnum r)
        {
            switch (r)
            {
                case RaceEnum.Forest:
                    return FOREST;
                case RaceEnum.Desert:
                    return DESERT;
                case RaceEnum.Cave:
                    return CAVE;
                case RaceEnum.Mountain:
                    return MOUNTAIN;
                case RaceEnum.Dark:
                    return DARK;
                case RaceEnum.Sea:
                    return SEA;
                default:
                    return FOREST;
                    //throw new Exception(string.Format("'{0}' is not a valid race.", r));
            }
        }

        public GeneInfo ConvertInt256ToGene(BigInteger code)
        {
            var c = code.ToByteArray();
            //var c = b.Reverse().ToArray();
            if (c.Length < 26)
            {
                throw new Exception(string.Format("Code has {0} bytes.", c.Length));
            }
            var g = new GeneInfo();
            g.Genre = ByteToGenre(c[0]);

            g.Skin = ByteToRace(c[SKIN]);
            g.SkinR1 = ByteToRace(c[SKIN + 1]);
            g.SkinR2 = ByteToRace(c[SKIN + 2]);

            g.Hair = ByteToRace(c[HAIR]);
            g.HairR1 = ByteToRace(c[HAIR + 1]);
            g.HairR2 = ByteToRace(c[HAIR + 2]);

            g.Eyes = ByteToRace(c[EYES]);
            g.EyesR1 = ByteToRace(c[EYES + 1]);
            g.EyesR2 = ByteToRace(c[EYES + 2]);

            g.Ear = ByteToRace(c[EAR]);
            g.EarR1 = ByteToRace(c[EAR + 1]);
            g.EarR2 = ByteToRace(c[EAR + 2]);

            g.Mouth = ByteToRace(c[MOUTH]);
            g.MouthR1 = ByteToRace(c[MOUTH + 1]);
            g.MouthR2 = ByteToRace(c[MOUTH + 2]);

            g.SkinColor = Color.FromArgb(c[COLORSKIN], c[COLORSKIN + 1], c[COLORSKIN + 2]);
            g.HairColor = Color.FromArgb(c[COLORHAIR], c[COLORHAIR + 1], c[COLORHAIR + 2]);
            g.EyesColor = Color.FromArgb(c[COLOREYES], c[COLOREYES + 1], c[COLOREYES + 2]);

            g.Race = ByteToRace(c[RACE]);

            g.Rarity = (RARITY < c.Length) ? c[RARITY] : 0;

            g.Code = code;

            return g;
        }

        public BigInteger ConvertGeneToInt256(GeneInfo g)
        {
            var i = new List<byte>();
            i.Add(GenreToByte(g.Genre));

            i.Add(RaceToByte(g.Skin));
            i.Add(RaceToByte(g.SkinR1));
            i.Add(RaceToByte(g.SkinR2));

            i.Add(RaceToByte(g.Hair));
            i.Add(RaceToByte(g.HairR1));
            i.Add(RaceToByte(g.HairR2));

            i.Add(RaceToByte(g.Eyes));
            i.Add(RaceToByte(g.EyesR1));
            i.Add(RaceToByte(g.EyesR2));

            i.Add(RaceToByte(g.Ear));
            i.Add(RaceToByte(g.EarR1));
            i.Add(RaceToByte(g.EarR2));

            i.Add(RaceToByte(g.Mouth));
            i.Add(RaceToByte(g.MouthR1));
            i.Add(RaceToByte(g.MouthR2));

            i.Add(g.SkinColor.R);
            i.Add(g.SkinColor.G);
            i.Add(g.SkinColor.B);

            i.Add(g.HairColor.R);
            i.Add(g.HairColor.G);
            i.Add(g.HairColor.B);

            i.Add(g.EyesColor.R);
            i.Add(g.EyesColor.G);
            i.Add(g.EyesColor.B);

            i.Add(RaceToByte(g.Race));
            i.Add((byte)g.Rarity);

            return new BigInteger(i.ToArray());
        }

        private RaceEnum RandomGene()
        {
            var genes = new List<RaceEnum>();
            genes.AddRange(Enum.GetValues<RaceEnum>());
            genes.Shuffle();
            return genes[0];
        }

        private IList<RaceEnum> MixGene(RaceEnum g1m, RaceEnum g2m, RaceEnum g1r1, RaceEnum g2r1, RaceEnum g1r2, RaceEnum g2r2)
        {
            var retorno = new List<RaceEnum>();

            var genesMM = new List<RaceEnum>();
            var genesR1 = new List<RaceEnum>();
            var genesR2 = new List<RaceEnum>();
            for (var i = 0; i < 3; i++)
            {
                genesMM.Add(g1m);
                genesMM.Add(g2m);
            }
            for (var i = 0; i < 2; i++)
            {
                genesMM.Add(g1r1);
                genesMM.Add(g2r1);
                genesMM.Add(g1r2);
                genesMM.Add(g2r2);
            }

            genesR1.Add(g1m);
            genesR1.Add(g1r1);
            genesR1.Add(g1r2);

            genesR2.Add(g1m);
            genesR2.Add(g1r1);
            genesR2.Add(g1r2);

            genesMM.Shuffle();
            genesR1.Shuffle();
            genesR2.Shuffle();
            var r = _rand.Next(1, 100);
            retorno.Add((r == 50 || r == 51) ? RandomGene() : genesMM[0]);
            retorno.Add((r == 50 || r == 51) ? RandomGene() : genesR1[0]);
            retorno.Add((r == 50 || r == 51) ? RandomGene() : genesR2[0]);
            return retorno;
        }

        private RaceEnum GetRace(GeneInfo g, RaceEnum r1, RaceEnum r2)
        {
            double race1 = 0, race2 = 0;
            race1 += (g.Skin == r1) ? 1 : 0;
            race1 += (g.SkinR1 == r1) ? 0.5 : 0;
            race1 += (g.SkinR2 == r1) ? 0.5 : 0;
            race1 += (g.Hair == r1) ? 1 : 0;
            race1 += (g.HairR1 == r1) ? 0.5 : 0;
            race1 += (g.HairR2 == r1) ? 0.5 : 0;
            race1 += (g.Eyes == r1) ? 1 : 0;
            race1 += (g.EyesR1 == r1) ? 0.5 : 0;
            race1 += (g.EyesR2 == r1) ? 0.5 : 0;
            race1 += (g.Ear == r1) ? 1 : 0;
            race1 += (g.EarR1 == r1) ? 0.5 : 0;
            race1 += (g.EarR2 == r1) ? 0.5 : 0;
            race1 += (g.Mouth == r1) ? 1 : 0;
            race1 += (g.MouthR1 == r1) ? 0.5 : 0;
            race1 += (g.MouthR2 == r1) ? 0.5 : 0;

            race2 += (g.Skin == r2) ? 1 : 0;
            race2 += (g.SkinR1 == r2) ? 0.5 : 0;
            race2 += (g.SkinR2 == r2) ? 0.5 : 0;
            race2 += (g.Hair == r2) ? 1 : 0;
            race2 += (g.HairR1 == r2) ? 0.5 : 0;
            race2 += (g.HairR2 == r2) ? 0.5 : 0;
            race2 += (g.Eyes == r2) ? 1 : 0;
            race2 += (g.EyesR1 == r2) ? 0.5 : 0;
            race2 += (g.EyesR2 == r2) ? 0.5 : 0;
            race2 += (g.Ear == r2) ? 1 : 0;
            race2 += (g.EarR1 == r2) ? 0.5 : 0;
            race2 += (g.EarR2 == r2) ? 0.5 : 0;
            race2 += (g.Mouth == r2) ? 1 : 0;
            race2 += (g.MouthR1 == r2) ? 0.5 : 0;
            race2 += (g.MouthR2 == r2) ? 0.5 : 0;

            if (race1 == race2)
            {
                return _rand.Next(1, 2) == 1 ? r1 : r2;
            }
            else
            {
                return race1 > race2 ? r1 : r2;
            }
        }

        public Color MixColor(Color c1, Color c2)
        {
            double r1 = c1.R, g1 = c1.G, b1 = c1.B;
            double r2 = c2.R, g2 = c2.G, b2 = c2.B;

            var r = Convert.ToInt32(Math.Floor((r1 + r2) / 2));
            var g = Convert.ToInt32(Math.Floor((g1 + g2) / 2));
            var b = Convert.ToInt32(Math.Floor((b1 + b2) / 2));

            return Color.FromArgb(r, g, b);
        }

        public int GetRarityByBox(GoboxEnum gobox)
        {
            int r = 0;
            switch (gobox)
            {
                case GoboxEnum.GoboxCommon:
                    r = _rand.Next(0, 255);
                    break;
                case GoboxEnum.GoboxUncommon:
                    r = 128 + _rand.Next(0, 127);
                    break;
                case GoboxEnum.GoboxRare:
                    r = 210 + _rand.Next(0, 45);
                    break;
                default:
                    throw new Exception("This box is not a goblin box");
                    break;
            }
            return r;
        }

        /*
        public int GetRarity(int rarity1, int rarity2)
        {
            var r1 = (double)GoblinUtils.GetGoblinEnumRarity(rarity1);
            var r2 = (double)GoblinUtils.GetGoblinEnumRarity(rarity2);
            int total = Convert.ToInt32(Math.Floor((r1 + r2) / 2));
            int rarity = 0;
            switch (total)
            {
                case 1:
                    rarity = GetRarityByBox(GoboxEnum.GoboxCommon);
                    break;
                case 2:
                    rarity = GetRarityByBox(GoboxEnum.GoboxUncommon);
                    break;
                case 3:
                    rarity = GetRarityByBox(GoboxEnum.GoboxRare);
                    break;
                case 4:
                    rarity = GetRarityByBox(GoboxEnum.GoboxRare);
                    break;
                default:
                    rarity = GetRarityByBox(GoboxEnum.GoboxCommon);
                    break;
            }
            return rarity;
        }
        */

        public GoboxEnum GetBoxByBreed(RarityEnum rarity1, RarityEnum rarity2)
        {
            var r1 = (double)rarity1;
            var r2 = (double)rarity2;
            int total = Convert.ToInt32(Math.Floor((r1 + r2) / 2));
            GoboxEnum rarity;
            switch (total)
            {
                case 0:
                    rarity = GoboxEnum.GoboxCommon;
                    break;
                case 1:
                    rarity = GoboxEnum.GoboxCommon;
                    break;
                case 2:
                    rarity = GoboxEnum.GoboxUncommon;
                    break;
                case 3:
                    rarity = GoboxEnum.GoboxRare;
                    break;
                case 4:
                    rarity = GoboxEnum.GoboxRare;
                    break;
                default:
                    rarity = GoboxEnum.GoboxCommon;
                    break;
            }
            return rarity;
        }

        public GeneInfo MixGenes(GeneInfo male, GeneInfo female)
        {
            var g = new GeneInfo();
            g.Genre = _rand.Next(1, 2) == 1 ? GenreEnum.Male : GenreEnum.Female;
            var skin = MixGene(male.Skin, female.Skin, male.SkinR1, female.SkinR1, male.SkinR2, female.SkinR2);
            g.Skin = skin[0];
            g.SkinR1 = skin[1];
            g.SkinR2 = skin[2];
            var hair = MixGene(male.Hair, female.Hair, male.HairR1, female.HairR1, male.HairR2, female.HairR2);
            g.Hair = hair[0];
            g.HairR1 = hair[1];
            g.HairR2 = hair[2];
            var ear = MixGene(male.Ear, female.Ear, male.EarR1, female.EarR1, male.EarR2, female.EarR2);
            g.Ear = ear[0];
            g.EarR1 = ear[1];
            g.EarR2 = ear[2];
            var eye = MixGene(male.Eyes, female.Eyes, male.EyesR1, female.EyesR1, male.EyesR2, female.EyesR2);
            g.Eyes = eye[0];
            g.EyesR1 = eye[1];
            g.EyesR2 = eye[2];
            var mouth = MixGene(male.Mouth, female.Mouth, male.MouthR1, female.MouthR1, male.MouthR2, female.MouthR2);
            g.Mouth = mouth[0];
            g.MouthR1 = mouth[1];
            g.MouthR2 = mouth[2];
            g.SkinColor = MixColor(male.SkinColor, female.SkinColor);
            g.HairColor = MixColor(male.HairColor, female.HairColor);
            g.EyesColor = MixColor(male.EyesColor, female.EyesColor);

            g.Race = GetRace(g, male.Race, female.Race);

            var r1 = GoblinUtils.GetGoblinEnumRarity(male.Rarity);
            var r2 = GoblinUtils.GetGoblinEnumRarity(female.Rarity);
            var box = GetBoxByBreed(r1, r2);
            g.Rarity = GetRarityByBox(box);

            //g.Rarity = GetRarity(male.Rarity, female.Rarity);
            return g;
        }
    }
}
