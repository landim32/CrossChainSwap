using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class User
    {
        public User()
        {
            AuctionIdBuyerNavigations = new HashSet<Auction>();
            AuctionIdUserNavigations = new HashSet<Auction>();
            DailyLogins = new HashSet<DailyLogin>();
            Finances = new HashSet<Finance>();
            GoblinSales = new HashSet<GoblinSale>();
            Goblins = new HashSet<Goblin>();
            Goboxes = new HashSet<Gobox>();
            GoldFinances = new HashSet<GoldFinance>();
            InverseIdReferralNavigation = new HashSet<User>();
            Logs = new HashSet<Log>();
            MaterialMarkets = new HashSet<MaterialMarket>();
            MiningHistories = new HashSet<MiningHistory>();
            MiningRankings = new HashSet<MiningRanking>();
            MiningRewards = new HashSet<MiningReward>();
            ReTweets = new HashSet<ReTweet>();
            UserItems = new HashSet<UserItem>();
            UserQuests = new HashSet<UserQuest>();
        }

        public long Id { get; set; }
        public string PublicAddress { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Gobi { get; set; }
        public int Gobblocked { get; set; }
        public DateTime? GobblockedDate { get; set; }
        public int Gwb { get; set; }
        public DateTime? GwdlastClaim { get; set; }
        public DateTime? GoblastClaim { get; set; }
        public DateTime? GoldLastClaim { get; set; }
        public int Status { get; set; }
        public long? IdReferral { get; set; }
        public string ReferralCode { get; set; }
        public string TwitterId { get; set; }
        public string FacebookId { get; set; }
        public string DiscordId { get; set; }
        public string TelegramId { get; set; }
        public DateTime? ImageMineDate { get; set; }
        public bool CanWithdrawal { get; set; }

        public virtual User IdReferralNavigation { get; set; }
        public virtual ICollection<Auction> AuctionIdBuyerNavigations { get; set; }
        public virtual ICollection<Auction> AuctionIdUserNavigations { get; set; }
        public virtual ICollection<DailyLogin> DailyLogins { get; set; }
        public virtual ICollection<Finance> Finances { get; set; }
        public virtual ICollection<GoblinSale> GoblinSales { get; set; }
        public virtual ICollection<Goblin> Goblins { get; set; }
        public virtual ICollection<Gobox> Goboxes { get; set; }
        public virtual ICollection<GoldFinance> GoldFinances { get; set; }
        public virtual ICollection<User> InverseIdReferralNavigation { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<MaterialMarket> MaterialMarkets { get; set; }
        public virtual ICollection<MiningHistory> MiningHistories { get; set; }
        public virtual ICollection<MiningRanking> MiningRankings { get; set; }
        public virtual ICollection<MiningReward> MiningRewards { get; set; }
        public virtual ICollection<ReTweet> ReTweets { get; set; }
        public virtual ICollection<UserItem> UserItems { get; set; }
        public virtual ICollection<UserQuest> UserQuests { get; set; }
    }
}
