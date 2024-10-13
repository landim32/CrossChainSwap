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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BtcAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("btc_address");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("hash");

                entity.Property(e => e.StxAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("stx_address");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
