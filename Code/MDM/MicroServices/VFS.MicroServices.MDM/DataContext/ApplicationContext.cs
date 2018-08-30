using Microsoft.EntityFrameworkCore;
using VFS.Common.Models.Masters;

namespace VFS.MicroServices.MDM.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Country> Country { get; set; }
        public virtual DbSet<Mission> Mission { get; set; }
        public virtual DbSet<CountryOfOperation> CountryOfOperation { get; set; }
        public virtual DbSet<Jurisdiction> Jurisdiction { get; set; }
        public virtual DbSet<JurisdictionMap> JurisdictionMap { get; set; }
        public virtual DbSet<UnitOps> UnitOps { get; set; }
        public virtual DbSet<MstcountryMap> MstcountryMap { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Country>(entity =>
        //    {
        //        entity.Property(e => e.Code)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.DialCode).HasMaxLength(100);

        //        entity.Property(e => e.Isocode2)
        //            .HasColumnName("ISOCode2")
        //            .HasMaxLength(2)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Isocode3)
        //            .HasColumnName("ISOCode3")
        //            .HasMaxLength(3)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Nationality)
        //            .HasMaxLength(200)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<CountryOfOperation>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //        entity.Property(e => e.Code)
        //            .IsRequired()
        //            .HasMaxLength(10)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(250);

        //        entity.HasOne(d => d.Country)
        //            .WithMany(p => p.CountryOfOperation)
        //            .HasForeignKey(d => d.CountryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Country_CountryOpsId");

        //        entity.HasOne(d => d.Mission)
        //            .WithMany(p => p.CountryOfOperation)
        //            .HasForeignKey(d => d.MissionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Mission_MissionId");
        //    });

        //    modelBuilder.Entity<Jurisdiction>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //        entity.Property(e => e.Code)
        //            .HasMaxLength(10)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(250);
        //    });

        //    modelBuilder.Entity<JurisdictionMap>(entity =>
        //    {
        //        entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

        //        entity.Property(e => e.CreatedDateUtc)
        //            .HasColumnName("CreatedDateUTC")
        //            .HasColumnType("datetime")
        //            .HasDefaultValueSql("(getutcdate())");

        //        entity.Property(e => e.ModifiedDateUtc)
        //            .HasColumnName("ModifiedDateUTC")
        //            .HasColumnType("datetime");

        //        entity.Property(e => e.StatusReason)
        //            .HasMaxLength(250)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.CountryOps)
        //            .WithMany(p => p.jurisdictionmap)
        //            .HasForeignKey(d => d.CountryOpsId)
        //            .HasConstraintName("FK_CountryOfOperation_JurisdictionMap");

        //        entity.HasOne(d => d.Jurisdiction)
        //            .WithMany(p => p.JurisdictionMap)
        //            .HasForeignKey(d => d.JurisdictionId)
        //            .HasConstraintName("FK_Jurisdiction_JurisdictionMapId");
        //    });
        //    modelBuilder.Entity<Mission>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //        entity.Property(e => e.Code)
        //            .IsRequired()
        //            .HasMaxLength(10)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(250);
        //    });
        //    modelBuilder.Entity<MstcountryMap>(entity =>
        //    {
        //        entity.ToTable("MSTCountryMap");

        //        entity.HasOne(d => d.Country)
        //            .WithMany(p => p.MstcountryMap)
        //            .HasForeignKey(d => d.CountryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Country_MSTCountryMap_Country");

        //        entity.HasOne(d => d.CountryOps)
        //            .WithMany(p => p.MstcountryMap)
        //            .HasForeignKey(d => d.CountryOpsId)
        //            .HasConstraintName("FK_MSTCountryMap_CountryOfOperation");

        //        entity.HasOne(d => d.Mission)
        //            .WithMany(p => p.MstcountryMap)
        //            .HasForeignKey(d => d.MissionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_MSTCountryMap_Mission");

        //        entity.HasOne(d => d.UnitOps)
        //            .WithMany(p => p.MstcountryMap)
        //            .HasForeignKey(d => d.UnitOpsId)
        //            .HasConstraintName("FK_MSTCountryMap_UnitOps");
        //    });
        //    modelBuilder.Entity<UnitOps>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //        entity.Property(e => e.Code)
        //            .IsRequired()
        //            .HasMaxLength(11)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(250)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.Jurisdiction)
        //            .WithMany(p => p.UnitOps)
        //            .HasForeignKey(d => d.JurisdictionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Juris_JurisdictId");
        //    });
        //}
    }
}
