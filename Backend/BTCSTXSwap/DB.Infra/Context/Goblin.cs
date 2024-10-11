using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Goblin
    {
        public Goblin()
        {
            Auctions = new HashSet<Auction>();
            GoblinEquipments = new HashSet<GoblinEquipment>();
            GoblinFeatures = new HashSet<GoblinFeature>();
            GoblinPerks = new HashSet<GoblinPerk>();
            GoblinRecharges = new HashSet<GoblinRecharge>();
            GoblinSales = new HashSet<GoblinSale>();
            InverseIdFatherNavigation = new HashSet<Goblin>();
            InverseIdMotherNavigation = new HashSet<Goblin>();
            InverseIdSpouseNavigation = new HashSet<Goblin>();
        }

        public long Id { get; set; }
        public byte[] IdToken { get; set; }
        public byte[] IdTokenFather { get; set; }
        public byte[] IdTokenMother { get; set; }
        public long IdUser { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? LastUserChange { get; set; }
        public long Xp { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Race { get; set; }
        public int Hair { get; set; }
        public int Ear { get; set; }
        public int Eye { get; set; }
        public int Mount { get; set; }
        public int Skin { get; set; }
        public int HairColor { get; set; }
        public int SkinColor { get; set; }
        public int EyeColor { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vigor { get; set; }
        public int Intelligence { get; set; }
        public int Charism { get; set; }
        public int Perception { get; set; }
        public byte[] ContractInventory { get; set; }
        public byte[] ContractBag { get; set; }
        public byte[] ContractMods { get; set; }
        public byte[] ContractSonsCount { get; set; }
        public byte[] ContractSpouse { get; set; }
        public byte[] ContractLastUpdateTime { get; set; }
        public byte[] ContractCooldownTime { get; set; }
        public int Status { get; set; }
        public int Rarity { get; set; }
        public bool HasImageMine { get; set; }
        public string BaseImagePath { get; set; }
        public long TokenId { get; set; }
        public long? IdFather { get; set; }
        public long? IdMother { get; set; }
        public long? IdSpouse { get; set; }
        public DateTime? CooldownTime { get; set; }
        public bool Minted { get; set; }
        public long? TokenIdFatherTmp { get; set; }
        public long? TokenIdMotherTmp { get; set; }
        public long? TokenIdSpouseTmp { get; set; }
        public byte[] Genes { get; set; }

        public virtual Goblin IdFatherNavigation { get; set; }
        public virtual Goblin IdMotherNavigation { get; set; }
        public virtual Goblin IdSpouseNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<GoblinEquipment> GoblinEquipments { get; set; }
        public virtual ICollection<GoblinFeature> GoblinFeatures { get; set; }
        public virtual ICollection<GoblinPerk> GoblinPerks { get; set; }
        public virtual ICollection<GoblinRecharge> GoblinRecharges { get; set; }
        public virtual ICollection<GoblinSale> GoblinSales { get; set; }
        public virtual ICollection<Goblin> InverseIdFatherNavigation { get; set; }
        public virtual ICollection<Goblin> InverseIdMotherNavigation { get; set; }
        public virtual ICollection<Goblin> InverseIdSpouseNavigation { get; set; }
    }
}
