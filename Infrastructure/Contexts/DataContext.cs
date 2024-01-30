

using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ChampionEntity> Champions { get; set; }
    public DbSet<LeagueEntity> Leagues { get; set; }
    public DbSet<TeamEntity> Teams { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<SoftwareProduct> SoftwareProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3214EC077EF9799F");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SoftwareProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Software__3214EC074DA028E3");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Size).WithMany(p => p.SoftwareProducts).HasConstraintName("FK__SoftwareP__SizeI__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
