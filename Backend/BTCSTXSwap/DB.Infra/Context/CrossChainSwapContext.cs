using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DB.Infra.Context
{
    public partial class CrossChainSwapContext : DbContext
    {
        public CrossChainSwapContext()
        {
        }

        public CrossChainSwapContext(DbContextOptions<CrossChainSwapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=15432;Database=crosschainswap;Username=postgres;Password=eaa69cpxy2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TxId)
                    .HasName("pk_tx");

                entity.ToTable("transactions");

                entity.Property(e => e.TxId)
                    .HasColumnName("tx_id")
                    .HasDefaultValueSql("nextval('transactions_tx_nid_seq'::regclass)");

                entity.Property(e => e.BtcAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("btc_address");

                entity.Property(e => e.BtcAmount).HasColumnName("btc_amount");

                entity.Property(e => e.BtcFee).HasColumnName("btc_fee");

                entity.Property(e => e.BtcTxid)
                    .HasMaxLength(64)
                    .HasColumnName("btc_txid")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StxAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("stx_address");

                entity.Property(e => e.StxAmount).HasColumnName("stx_amount");

                entity.Property(e => e.StxFee).HasColumnName("stx_fee");

                entity.Property(e => e.StxTxid)
                    .HasMaxLength(64)
                    .HasColumnName("stx_txid")
                    .IsFixedLength(true);

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");
            });

            modelBuilder.Entity<TransactionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("pk_tx_log");

                entity.ToTable("transaction_logs");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasDefaultValueSql("nextval('transactions_log_log_id_seq'::regclass)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.LogType)
                    .HasColumnName("log_type")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Message)
                    .HasMaxLength(300)
                    .HasColumnName("message");

                entity.Property(e => e.TxId).HasColumnName("tx_id");

                entity.HasOne(d => d.Tx)
                    .WithMany(p => p.TransactionLogs)
                    .HasForeignKey(d => d.TxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tx_log");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BtcAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("btc_address");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("create_at");

                entity.Property(e => e.Hash)
                    .HasMaxLength(64)
                    .HasColumnName("hash");

                entity.Property(e => e.StxAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("stx_address");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("update_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
