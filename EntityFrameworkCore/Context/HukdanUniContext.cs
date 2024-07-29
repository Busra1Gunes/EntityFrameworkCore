using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore;

public partial class HukdanUniContext : DbContext
{
    public HukdanUniContext()
    {
    }

    public HukdanUniContext(DbContextOptions<HukdanUniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsgariUcretKatsayi> AsgariUcretKatsayis { get; set; }

    public virtual DbSet<AsgariUcretler> AsgariUcretlers { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Initial Catalog=hukdanUNI;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<AsgariUcretKatsayi>(entity =>
        {
            entity.ToTable("asgari_ucret_katsayi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Indirim).HasColumnName("indirim");
            entity.Property(e => e.Katsayi)
                .HasMaxLength(50)
                .HasColumnName("katsayi");
            entity.Property(e => e.Yil)
                .HasMaxLength(50)
                .HasColumnName("yil");
        });

        modelBuilder.Entity<AsgariUcretler>(entity =>
        {
            entity.ToTable("asgariUcretler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Burut)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("burut");
            entity.Property(e => e.Donem)
                .HasMaxLength(30)
                .HasColumnName("donem");
            entity.Property(e => e.Net)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("net");
            entity.Property(e => e.Silindi).HasColumnName("silindi");
            entity.Property(e => e.Sure)
                .HasMaxLength(10)
                .HasColumnName("sure");
            entity.Property(e => e.Tur)
                .HasMaxLength(50)
                .HasColumnName("tur");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
