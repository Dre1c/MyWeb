using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models;

public partial class PracticContext : DbContext
{
    public PracticContext()
    {
    }

    public PracticContext(DbContextOptions<PracticContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Lot> Lots { get; set; }

    public virtual DbSet<MarketDatum> MarketData { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Assets__991B5946DA7FE951");

            entity.Property(e => e.AssetId)
                .ValueGeneratedNever()
                .HasColumnName("Asset_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.AssetName)
                .HasMaxLength(20)
                .HasColumnName("Asset_name");
            entity.Property(e => e.AssetType)
                .HasMaxLength(10)
                .HasColumnName("Asset_type");
            entity.Property(e => e.Currency)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");
            entity.Property(e => e.TheDate)
                .HasColumnType("datetime")
                .HasColumnName("The_Date");
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => e.LotId).HasName("PK__Lot__E66E914C96BC8976");

            entity.ToTable("Lot");

            entity.Property(e => e.LotId)
                .ValueGeneratedNever()
                .HasColumnName("Lot_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.AssetId).HasColumnName("Asset_ID");
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");
            entity.Property(e => e.PortfolioId).HasColumnName("Portfolio_ID");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("Purchase_Date");
            entity.Property(e => e.PurchasePrice).HasColumnName("Purchase_Price");
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.Asset).WithMany(p => p.Lots)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lot_Assets");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Lots)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lot_Portfolio");

            entity.HasOne(d => d.Users).WithMany(p => p.Lots)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lot_Users");
        });

        modelBuilder.Entity<MarketDatum>(entity =>
        {
            entity.HasKey(e => e.MarketId).HasName("PK__Market_D__3F95245DC25C63FD");

            entity.ToTable("Market_Data");

            entity.Property(e => e.MarketId)
                .ValueGeneratedNever()
                .HasColumnName("Market_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.AssetCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Asset_creation_date");
            entity.Property(e => e.AssetId).HasColumnName("Asset_ID");
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");

            entity.HasOne(d => d.Asset).WithMany(p => p.MarketData)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Market_Data_Assets");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK__Portfoli__778784B436FFB44C");

            entity.ToTable("Portfolio");

            entity.Property(e => e.PortfolioId)
                .ValueGeneratedNever()
                .HasColumnName("Portfolio_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");
            entity.Property(e => e.PortfolioName)
                .HasMaxLength(20)
                .HasColumnName("Portfolio_name");
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.Users).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Portfolio_Users");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionsId).HasName("PK__Transact__6E23801FAA1FA166");

            entity.Property(e => e.TransactionsId)
                .ValueGeneratedNever()
                .HasColumnName("Transactions_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.AssetId).HasColumnName("Asset_ID");
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");
            entity.Property(e => e.PortfolioId).HasColumnName("Portfolio_ID");
            entity.Property(e => e.TheDate)
                .HasColumnType("datetime")
                .HasColumnName("The_Date");
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.Asset).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Assets");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Portfolio");

            entity.HasOne(d => d.Users).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__Users__EB68290DD2AA3A98");

            entity.Property(e => e.UsersId)
                .ValueGeneratedNever()
                .HasColumnName("Users_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.AddedTime)
                .HasColumnType("datetime")
                .HasColumnName("Added_time");
            entity.Property(e => e.DeletetBy).HasColumnName("Deletet_by");
            entity.Property(e => e.DeletetTime)
                .HasColumnType("datetime")
                .HasColumnName("Deletet_time");
            entity.Property(e => e.EditBy).HasColumnName("Edit_by");
            entity.Property(e => e.EditTime)
                .HasColumnType("datetime")
                .HasColumnName("Edit_time");
            entity.Property(e => e.Pasword).HasMaxLength(20);
            entity.Property(e => e.UsersName)
                .HasMaxLength(20)
                .HasColumnName("Users_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
