using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pr_model.Models;

public partial class PGDB_01Context : DbContext
{
    public PGDB_01Context(DbContextOptions<PGDB_01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Book { get; set; }

    public virtual DbSet<Log> Log { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BigImage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryRemarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Packing)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Log4Net");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Level).HasMaxLength(50);
            entity.Property(e => e.Logger).HasMaxLength(255);
            entity.Property(e => e.Thread).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.NickName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
