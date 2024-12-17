using System;
using System.Collections.Generic;
using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Data;

public partial class AddDbContext : DbContext
{
    public AddDbContext()
    {
    }

    public AddDbContext(DbContextOptions<AddDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExamOrder> ExamOrders { get; set; }

    public virtual DbSet<ExamOrderProduct> ExamOrderProducts { get; set; }

    public virtual DbSet<ExamPickupPoint> ExamPickupPoints { get; set; }

    public virtual DbSet<ExamProduct> ExamProducts { get; set; }

    public virtual DbSet<ExamRole> ExamRoles { get; set; }

    public virtual DbSet<ExamUser> ExamUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MSI; Database=FinalWork1101; Trusted_Connection=True; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExamOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ExamOrder");

            entity.ToTable("ExamOrder");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.PickupPointIndexNavigation).WithMany(p => p.ExamOrders)
                .HasForeignKey(d => d.PickupPointIndex)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamOrder_ExamPickupPoint");

            entity.HasOne(d => d.User).WithMany(p => p.ExamOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ExamOrder_ExamUser");
        });

        modelBuilder.Entity<ExamOrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber }).HasName("PK__ExamOrde__817A266255BBC081");

            entity.ToTable("ExamOrderProduct");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.ExamOrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamOrder__Order");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.ExamOrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamOrder__Produ__412EB0B6");
        });

        modelBuilder.Entity<ExamPickupPoint>(entity =>
        {
            entity.HasKey(e => e.PickupPointIndex).HasName("PK_ExamPickupPointIndex");

            entity.ToTable("ExamPickupPoint");

            entity.Property(e => e.PickupPointIndex).ValueGeneratedNever();
            entity.Property(e => e.Building).HasMaxLength(5);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<ExamProduct>(entity =>
        {
            entity.HasKey(e => e.ArticleNumber).HasName("PK__ExamProd__2EA7DCD5BF55BCD9");

            entity.ToTable("ExamProduct");

            entity.Property(e => e.ArticleNumber).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Manufacturer).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        modelBuilder.Entity<ExamRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ExamRole__8AFACE3AA2D40FB8");

            entity.ToTable("ExamRole");

            entity.Property(e => e.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ExamUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ExamUser__1788CCAC0829F7A9");

            entity.ToTable("ExamUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.ExamUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamUser_ExamRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
