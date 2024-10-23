﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB.Infra.Context;

public partial class NoChainSwapContext : DbContext
{
    public NoChainSwapContext()
    {
    }

    public NoChainSwapContext(DbContextOptions<NoChainSwapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=167.172.240.71;Port=5432;Database=crosschainswap;Username=postgres;Password=eaa69cpxy2");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TxId).HasName("pk_tx");

            entity.ToTable("transactions");

            entity.Property(e => e.TxId)
                .HasDefaultValueSql("nextval('transactions_tx_nid_seq'::regclass)")
                .HasColumnName("tx_id");
            entity.Property(e => e.BtcAddress)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("btc_address");
            entity.Property(e => e.BtcAmount).HasColumnName("btc_amount");
            entity.Property(e => e.BtcFee).HasColumnName("btc_fee");
            entity.Property(e => e.BtcTxid)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("btc_txid");
            entity.Property(e => e.CreateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StxAddress)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("stx_address");
            entity.Property(e => e.StxAmount).HasColumnName("stx_amount");
            entity.Property(e => e.StxFee).HasColumnName("stx_fee");
            entity.Property(e => e.StxTxid)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("stx_txid");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("pk_tx_log");

            entity.ToTable("transaction_logs");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.LogType)
                .HasDefaultValue(1)
                .HasColumnName("log_type");
            entity.Property(e => e.Message)
                .HasMaxLength(300)
                .HasColumnName("message");
            entity.Property(e => e.TxId).HasColumnName("tx_id");

            entity.HasOne(d => d.Tx).WithMany(p => p.TransactionLogs)
                .HasForeignKey(d => d.TxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tx_log");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BtcAddress)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("btc_address");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .HasColumnName("hash");
            entity.Property(e => e.StxAddress)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("stx_address");
            entity.Property(e => e.UpdateAt).HasColumnName("update_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
