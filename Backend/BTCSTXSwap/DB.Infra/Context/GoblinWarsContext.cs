using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DB.Infra.Context
{
    public partial class GoblinWarsContext : DbContext
    {
        public GoblinWarsContext()
        {
        }

        public GoblinWarsContext(DbContextOptions<GoblinWarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<DailyLogin> DailyLogins { get; set; }
        public virtual DbSet<DailyLoginDay> DailyLoginDays { get; set; }
        public virtual DbSet<EnergyCost> EnergyCosts { get; set; }
        public virtual DbSet<EquipmentAttribute> EquipmentAttributes { get; set; }
        public virtual DbSet<EquipmentAttributeBonu> EquipmentAttributeBonus { get; set; }
        public virtual DbSet<Finance> Finances { get; set; }
        public virtual DbSet<Goblin> Goblins { get; set; }
        public virtual DbSet<GoblinAttributeBonu> GoblinAttributeBonus { get; set; }
        public virtual DbSet<GoblinEquipment> GoblinEquipments { get; set; }
        public virtual DbSet<GoblinFeature> GoblinFeatures { get; set; }
        public virtual DbSet<GoblinPerk> GoblinPerks { get; set; }
        public virtual DbSet<GoblinRecharge> GoblinRecharges { get; set; }
        public virtual DbSet<GoblinSale> GoblinSales { get; set; }
        public virtual DbSet<Gobox> Goboxes { get; set; }
        public virtual DbSet<GoldFinance> GoldFinances { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MaterialMarket> MaterialMarkets { get; set; }
        public virtual DbSet<MiningHistory> MiningHistories { get; set; }
        public virtual DbSet<MiningRanking> MiningRankings { get; set; }
        public virtual DbSet<MiningReward> MiningRewards { get; set; }
        public virtual DbSet<MiningTotalHashPower> MiningTotalHashPowers { get; set; }
        public virtual DbSet<PendingTransaction> PendingTransactions { get; set; }
        public virtual DbSet<ReTweet> ReTweets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserItem> UserItems { get; set; }
        public virtual DbSet<UserMiningEstimativeReward> UserMiningEstimativeRewards { get; set; }
        public virtual DbSet<UserQuest> UserQuests { get; set; }
        public virtual DbSet<UserQuestsGoblin> UserQuestsGoblins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=GoblinWars;User Id=sa;Password=Your_password123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Auction>(entity =>
            {
                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(32, 18)");

                entity.HasOne(d => d.IdBuyerNavigation)
                    .WithMany(p => p.AuctionIdBuyerNavigations)
                    .HasForeignKey(d => d.IdBuyer)
                    .HasConstraintName("FK__Auctions__IdBuye__0F624AF8");

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.IdGoblin)
                    .HasConstraintName("Auctions_Goblin_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AuctionIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Auctions__IdUser__10566F31");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<DailyLogin>(entity =>
            {
                entity.ToTable("DailyLogin");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DailyLogins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyLogi__IdUse__114A936A");
            });

            modelBuilder.Entity<DailyLoginDay>(entity =>
            {
                entity.HasKey(e => e.IdDay)
                    .HasName("PK__DailyLog__0E65962AD7180459");

                entity.ToTable("DailyLoginDay");

                entity.Property(e => e.LimitDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdDailyNavigation)
                    .WithMany(p => p.DailyLoginDays)
                    .HasForeignKey(d => d.IdDaily)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyLogi__IdDai__123EB7A3");
            });

            modelBuilder.Entity<EnergyCost>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EnergyCost");

                entity.Property(e => e.EnergyCost1).HasColumnName("EnergyCost");

                entity.Property(e => e.EnergyPercent).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentAttribute>(entity =>
            {
                entity.ToTable("EquipmentAttribute");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EquipmentAttributeBonu>(entity =>
            {
                entity.HasKey(e => new { e.IdAttribute, e.ItemKey })
                    .HasName("PK__Equipmen__EE4EF06E2C0115A4");

                entity.Property(e => e.Value).HasColumnType("decimal(12, 4)");

                entity.HasOne(d => d.IdAttributeNavigation)
                    .WithMany(p => p.EquipmentAttributeBonus)
                    .HasForeignKey(d => d.IdAttribute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__IdAtt__1332DBDC");
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Balance).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Credit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Debit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Fee).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Gas).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(250);

                entity.Property(e => e.TxHash).HasMaxLength(200);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Finances)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Finances__IdUser__14270015");
            });

            modelBuilder.Entity<Goblin>(entity =>
            {
                entity.ToTable("Goblin");

                entity.Property(e => e.BaseImagePath).HasMaxLength(200);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.ContractBag)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractCooldownTime)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractInventory)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractLastUpdateTime)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractMods)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractSonsCount)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.ContractSpouse)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.CooldownTime).HasColumnType("datetime");

                entity.Property(e => e.Genes)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.Genre)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.IdToken)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.IdTokenFather)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.IdTokenMother)
                    .HasMaxLength(256)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUserChange).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdFatherNavigation)
                    .WithMany(p => p.InverseIdFatherNavigation)
                    .HasForeignKey(d => d.IdFather)
                    .HasConstraintName("Goblin_IdFather_FK");

                entity.HasOne(d => d.IdMotherNavigation)
                    .WithMany(p => p.InverseIdMotherNavigation)
                    .HasForeignKey(d => d.IdMother)
                    .HasConstraintName("Goblin_IdMother_FK");

                entity.HasOne(d => d.IdSpouseNavigation)
                    .WithMany(p => p.InverseIdSpouseNavigation)
                    .HasForeignKey(d => d.IdSpouse)
                    .HasConstraintName("Goblin_IdSpouse_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Goblins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Goblin__IdUser__151B244E");
            });

            modelBuilder.Entity<GoblinAttributeBonu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GoblinAttributeBonus");

                entity.Property(e => e.MiningPower).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<GoblinEquipment>(entity =>
            {
                entity.ToTable("GoblinEquipment");

                entity.Property(e => e.DataAlteracao).HasColumnType("datetime");

                entity.Property(e => e.ItemCategory)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.GoblinEquipments)
                    .HasForeignKey(d => d.IdGoblin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoblinEqu__IdGob__18EBB532");
            });

            modelBuilder.Entity<GoblinFeature>(entity =>
            {
                entity.HasKey(e => new { e.IdGoblin, e.FeatureType })
                    .HasName("PK__GoblinFe__23044818E93A6BAC");

                entity.ToTable("GoblinFeature");

                entity.Property(e => e.Description).HasMaxLength(32);

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.GoblinFeatures)
                    .HasForeignKey(d => d.IdGoblin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoblinFea__IdGob__19DFD96B");
            });

            modelBuilder.Entity<GoblinPerk>(entity =>
            {
                entity.ToTable("GoblinPerk");

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.GoblinPerks)
                    .HasForeignKey(d => d.IdGoblin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoblinPer__IdGob__1AD3FDA4");
            });

            modelBuilder.Entity<GoblinRecharge>(entity =>
            {
                entity.ToTable("GoblinRecharge");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cost).HasColumnType("decimal(16, 10)");

                entity.Property(e => e.LastRecharge).HasColumnType("datetime");

                entity.Property(e => e.RestartDate).HasColumnType("datetime");

                entity.Property(e => e.RestartTiredDate).HasColumnType("datetime");

                entity.Property(e => e.StopDate).HasColumnType("datetime");

                entity.Property(e => e.TiredDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.GoblinRecharges)
                    .HasForeignKey(d => d.IdGoblin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoblinRec__IdGob__1BC821DD");
            });

            modelBuilder.Entity<GoblinSale>(entity =>
            {
                entity.ToTable("GoblinSale");

                entity.Property(e => e.DatePaidOut).HasColumnType("datetime");

                entity.Property(e => e.DatePending).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.TransactionHash)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.BuyingIdUserNavigation)
                    .WithMany(p => p.GoblinSales)
                    .HasForeignKey(d => d.BuyingIdUser)
                    .HasConstraintName("FK__GoblinSal__Buyin__1CBC4616");

                entity.HasOne(d => d.IdGoblinNavigation)
                    .WithMany(p => p.GoblinSales)
                    .HasForeignKey(d => d.IdGoblin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoblinSal__IdGob__1DB06A4F");
            });

            modelBuilder.Entity<Gobox>(entity =>
            {
                entity.ToTable("Gobox");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Goboxes)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gobox__IdUser__1EA48E88");
            });

            modelBuilder.Entity<GoldFinance>(entity =>
            {
                entity.Property(e => e.Credit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Debit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.GobiCredit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.GobiDebit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.TransactionGobiTax).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.TransactionGoldTax).HasColumnType("decimal(32, 18)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.GoldFinances)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__GoldFinan__IdUse__2FCF1A8A");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__Logs__0C54DBC63EC2B073");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LogType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('INFO')");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Logs__IdUser__208CD6FA");
            });

            modelBuilder.Entity<MaterialMarket>(entity =>
            {
                entity.ToTable("MaterialMarket");

                entity.Property(e => e.GoldCredit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.GoldDebit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MaterialMarkets)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__MaterialM__IdUse__3D2915A8");
            });

            modelBuilder.Entity<MiningHistory>(entity =>
            {
                entity.ToTable("MiningHistory");

                entity.Property(e => e.HashForMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.HashForWeek).HasDefaultValueSql("((0))");

                entity.Property(e => e.RewardDate).HasColumnType("datetime");

                entity.Property(e => e.RewardType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('W')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MiningHistories)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MiningHis__IdUse__2180FB33");
            });

            modelBuilder.Entity<MiningRanking>(entity =>
            {
                entity.ToTable("MiningRanking");

                entity.Property(e => e.HashForMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.HashForWeek).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastMining).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Percent).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.RewardPerMonth).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.RewardPerSecond).HasColumnType("decimal(32, 18)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MiningRankings)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MiningRan__IdUse__22751F6C");
            });

            modelBuilder.Entity<MiningReward>(entity =>
            {
                entity.ToTable("MiningReward");

                entity.Property(e => e.ClaimDate).HasColumnType("datetime");

                entity.Property(e => e.Credit).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.Fee).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.GobiValue).HasColumnType("decimal(32, 18)");

                entity.Property(e => e.HashValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MiningRewards)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MiningRew__IdUse__236943A5");
            });

            modelBuilder.Entity<MiningTotalHashPower>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MiningTotalHashPower");

                entity.Property(e => e.HashPower).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<PendingTransaction>(entity =>
            {
                entity.HasKey(e => e.TxHash)
                    .HasName("PK__PendingT__127EEB9F45C723D5");

                entity.ToTable("PendingTransaction");

                entity.Property(e => e.TxHash).HasMaxLength(200);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(32, 18)");
            });

            modelBuilder.Entity<ReTweet>(entity =>
            {
                entity.Property(e => e.Tweet)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ReTweets)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReTweets__IdUser__245D67DE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.PublicAddress, "UQ__User__6FE48343CA661BD1")
                    .IsUnique();

                entity.Property(e => e.DiscordId).HasMaxLength(80);

                entity.Property(e => e.Email).HasMaxLength(160);

                entity.Property(e => e.FacebookId).HasMaxLength(80);

                entity.Property(e => e.Gobblocked).HasColumnName("GOBBlocked");

                entity.Property(e => e.GobblockedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("GOBBlockedDate");

                entity.Property(e => e.Gobi)
                    .HasColumnType("decimal(32, 18)")
                    .HasColumnName("GOBI");

                entity.Property(e => e.GoblastClaim)
                    .HasColumnType("datetime")
                    .HasColumnName("GOBLastClaim");

                entity.Property(e => e.GoldLastClaim).HasColumnType("datetime");

                entity.Property(e => e.Gwb).HasColumnName("GWB");

                entity.Property(e => e.GwdlastClaim)
                    .HasColumnType("datetime")
                    .HasColumnName("GWDLastClaim");

                entity.Property(e => e.Hash)
                    .HasMaxLength(500)
                    .HasColumnName("HASH");

                entity.Property(e => e.ImageMineDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.PublicAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReferralCode).HasMaxLength(40);

                entity.Property(e => e.TelegramId).HasMaxLength(80);

                entity.Property(e => e.TwitterId).HasMaxLength(80);

                entity.HasOne(d => d.IdReferralNavigation)
                    .WithMany(p => p.InverseIdReferralNavigation)
                    .HasForeignKey(d => d.IdReferral)
                    .HasConstraintName("FK_REFERRAL");
            });

            modelBuilder.Entity<UserItem>(entity =>
            {
                entity.HasKey(e => e.IdItem)
                    .HasName("PK__UserItem__51E84262EBEF84C8");

                entity.Property(e => e.Qtde).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserItems)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserItems__IdUse__2645B050");
            });

            modelBuilder.Entity<UserMiningEstimativeReward>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("USerMiningEstimativeReward");

                entity.Property(e => e.DailyRecharge)
                    .HasColumnType("numeric(31, 8)")
                    .HasColumnName("dailyRecharge");

                entity.Property(e => e.DailyReward)
                    .HasColumnType("decimal(36, 19)")
                    .HasColumnName("dailyReward");

                entity.Property(e => e.HashPower).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.RealDailyReward).HasColumnType("numeric(38, 15)");
            });

            modelBuilder.Entity<UserQuest>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Percent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserQuests)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserQuest__IdUse__2739D489");
            });

            modelBuilder.Entity<UserQuestsGoblin>(entity =>
            {
                entity.HasOne(d => d.IdQuestNavigation)
                    .WithMany(p => p.UserQuestsGoblins)
                    .HasForeignKey(d => d.IdQuest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserQuest__IdQue__282DF8C2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
