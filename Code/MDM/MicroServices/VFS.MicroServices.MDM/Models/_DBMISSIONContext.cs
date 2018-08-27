using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VFS.MicroServices.MDM.Models
{
    public partial class _DBMISSIONContext : DbContext
    {
        public _DBMISSIONContext()
        {
        }

        public _DBMISSIONContext(DbContextOptions<_DBMISSIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryOfOperation> CountryOfOperation { get; set; }
        public virtual DbSet<Jurisdiction> Jurisdiction { get; set; }
        public virtual DbSet<JurisdictionMap> JurisdictionMap { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LanguageMap> LanguageMap { get; set; }
        public virtual DbSet<Mission> Mission { get; set; }
        public virtual DbSet<MstcountryLangMap> MstcountryLangMap { get; set; }
        public virtual DbSet<MstcountryMap> MstcountryMap { get; set; }
        public virtual DbSet<Mstlookup> Mstlookup { get; set; }
        public virtual DbSet<UnitOps> UnitOps { get; set; }

        // Unable to generate entity type for table 'dbo.MasterTableList'. Please see the warning messages.

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LV054211001336\\SQLEXPRESS;Database=_DBMISSION;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DialCode).HasMaxLength(100);

                entity.Property(e => e.Isocode2)
                    .HasColumnName("ISOCode2")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Isocode3)
                    .HasColumnName("ISOCode3")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CountryOfOperation>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryOfOperation)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_CountryOpsId");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.CountryOfOperation)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mission_MissionId");
            });

            modelBuilder.Entity<Jurisdiction>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<JurisdictionMap>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("CreatedDateUTC")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedDateUtc)
                    .HasColumnName("ModifiedDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusReason)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryOps)
                    .WithMany(p => p.JurisdictionMap)
                    .HasForeignKey(d => d.CountryOpsId)
                    .HasConstraintName("FK_CountryOfOperation_JurisdictionMap");

                entity.HasOne(d => d.Jurisdiction)
                    .WithMany(p => p.JurisdictionMap)
                    .HasForeignKey(d => d.JurisdictionId)
                    .HasConstraintName("FK_Jurisdiction_JurisdictionMapId");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IsDeletedNavigation)
                    .WithMany(p => p.Language)
                    .HasForeignKey(d => d.IsDeleted)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MSTLookup_IsDeleted");
            });

            modelBuilder.Entity<LanguageMap>(entity =>
            {
                entity.HasOne(d => d.CountryOps)
                    .WithMany(p => p.LanguageMap)
                    .HasForeignKey(d => d.CountryOpsId)
                    .HasConstraintName("FK_LanguageMap_CountryOfOperation");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LanguageMap)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Language_LanguageMapId");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.LanguageMap)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LanguageMap_Mission");

                entity.HasOne(d => d.UnitOps)
                    .WithMany(p => p.LanguageMap)
                    .HasForeignKey(d => d.UnitOpsId)
                    .HasConstraintName("FK_LanguageMap_UnitOps");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<MstcountryLangMap>(entity =>
            {
                entity.ToTable("MSTCountryLangMap");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstcountryLangMap)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_MSTCountryLangMap_Country");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.MstcountryLangMap)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_MSTCountryLangMap_Language");
            });

            modelBuilder.Entity<MstcountryMap>(entity =>
            {
                entity.ToTable("MSTCountryMap");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstcountryMap)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_MSTCountryMap_Country");

                entity.HasOne(d => d.CountryOps)
                    .WithMany(p => p.MstcountryMap)
                    .HasForeignKey(d => d.CountryOpsId)
                    .HasConstraintName("FK_MSTCountryMap_CountryOfOperation");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MstcountryMap)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MSTCountryMap_Mission");

                entity.HasOne(d => d.UnitOps)
                    .WithMany(p => p.MstcountryMap)
                    .HasForeignKey(d => d.UnitOpsId)
                    .HasConstraintName("FK_MSTCountryMap_UnitOps");
            });

            modelBuilder.Entity<Mstlookup>(entity =>
            {
                entity.ToTable("MSTLookup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnitOps>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Jurisdiction)
                    .WithMany(p => p.UnitOps)
                    .HasForeignKey(d => d.JurisdictionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juris_JurisdictId");
            });
        }
    }
}
