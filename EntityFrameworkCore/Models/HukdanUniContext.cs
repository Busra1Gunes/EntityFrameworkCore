using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Models;

public partial class HukdanUniContext : DbContext
{
    public HukdanUniContext()
    {
    }

    public HukdanUniContext(DbContextOptions<HukdanUniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DosyaTurleri> DosyaTurleris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AYZASOFT-0000;Initial Catalog=hukdanUNI;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<DosyaTurleri>(entity =>
        {
            entity.ToTable("dosya_turleri");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .HasColumnName("ad");
            entity.Property(e => e.Silindi).HasColumnName("silindi");
            entity.Property(e => e.Sira).HasColumnName("sira");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
