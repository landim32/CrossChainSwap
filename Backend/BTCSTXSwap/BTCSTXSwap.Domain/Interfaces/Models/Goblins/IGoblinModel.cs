using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Goblins
{
    public interface IGoblinModel
    {
        long Id { get; set; }
        BigInteger Genes { get; set; }
        //bool Ativo { get; set; }
        long IdUser { get; set; }
        string Username { get; set; }
        long TokenId { get; set; }
        long? TokenIdFatherTmp { get; set; }
        long? TokenIdMotherTmp { get; set; }
        long? TokenIdSpouseTmp { get; set; }
        long? IdFather { get; set; }
        long? IdMother { get; set; }
        long? IdSpouse { get; set; }
        long? FatherTokenId { get; set; }
        long? MotherTokenId { get; set; }
        long? SpouseTokenId { get; set; }
        DateTime? CooldownTime { get; set; }
        DateTime Birthday { get; set; }
        DateTime? LastUserChange { get; set; }
        int Xp { get; set; }
        string Name { get; set; }
        //string ImageURL { get; set; }
        //string HeadImageURL { get; set; }
        //DateTime? Busy { get; set; }
        GenreEnum Genre { get; set; }
        RaceEnum Race { get; set; }
        RaceEnum Hair { get; set; }
        RaceEnum Ear { get; set; }
        RaceEnum Eye { get; set; }
        RaceEnum Mount { get; set; }
        RaceEnum Skin { get; set; }
        Color HairColor { get; set; }
        Color SkinColor { get; set; }
        Color EyeColor { get; set; }
        int Strength { get; set; }
        int Agility { get; set; }
        int Vigor { get; set; }
        int Intelligence { get; set; }
        int Charism { get; set; }
        int Perception { get; set; }
        GoblinStatusEnum Status { get; set; }
        int Rarity { get; set; }
        RarityEnum RarityEnum { get; }
        long QuestAffinity { get; set; }
        bool HasImageMine { get; set; }
        string BaseImagePath { get; set; }
        bool Minted { get; set; }

        string GetImageUrl();
        string GetHeadImageUrl();
        IGoblinModel GetById(long idGoblin);
        IGoblinModel GetByTokenId(long tokenId, bool forced = false);
        long GetIdByTokenId(long tokenId);
        int GetSonsCount();
        IEnumerable<IGoblinModel> ListByUserWithCursor(long idUser, int cursor, int limit);
        IEnumerable<IGoblinModel> ListByUser(long idUser, int page, int itemsPerPage, out int balance);
        IEnumerable<IGoblinModel> ListSons(long idGoblin, int page, out int balance);
        IEnumerable<IGoblinModel> ListBrothers(long idGoblin, int page, out int balance);
        IEnumerable<IGoblinModel> ListGoblinCanBreed(long idGoblin, int cursor, int limit);

        IEnumerable<IGoblinPerkModel> ListPerks();
        void AddPerk(GoblinPerkEnum PerkKey);
        void ClearPerks();

        bool IsAvaliable();
        void DoBasic();
        void ChangeUser(long idUser);
        void DoMint(long idUser);
        void Deposit(long idUser);
        void Claimed(long idUser);

        //public string NewUID();

        #region Obsoleto
        [Obsolete]
        string UserAddress { get; set; }
        [Obsolete]
        BigInteger IdTokenOld { get; set; }
        [Obsolete]
        BigInteger IdTokenFather { get; set; }
        [Obsolete]
        BigInteger IdTokenMother { get; set; }
        [Obsolete]
        BigInteger Mods { get; set; }
        [Obsolete]
        BigInteger Inventory { get; set; }
        [Obsolete]
        BigInteger Bag { get; set; }
        [Obsolete]
        BigInteger SpouseWithId { get; set; }
        [Obsolete]
        BigInteger SonsCount { get; set; }
        [Obsolete]
        BigInteger LastUpdateTime { get; set; }
        [Obsolete]
        BigInteger CooldownTimeOld { get; set; }
        #endregion
    }
}
