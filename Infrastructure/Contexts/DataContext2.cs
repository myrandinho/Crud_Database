using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext2 : DbContext
{
    public DataContext2()
    {
    }

    public DataContext2(DbContextOptions<DataContext2> options)
        : base(options)
    {
    }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<SoftwareProduct> SoftwareProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3214EC074C4A769B");
        });

        modelBuilder.Entity<SoftwareProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Software__3214EC07F32C3435");

            entity.HasOne(d => d.Size).WithMany(p => p.SoftwareProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareP__SizeI__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
