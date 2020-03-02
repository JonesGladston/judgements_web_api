using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webApiApp.Models
{
    public partial class judgement_dbContext : DbContext
    {
        public judgement_dbContext()
        {
        }

        public judgement_dbContext(DbContextOptions<judgement_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Cases> cases { get; set; }
        public virtual DbSet<Defendants> Defendants { get; set; }
        public virtual DbSet<Plaintiffs> Plaintiffs { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=judgement_db;Username=jones;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("ar_internal_metadata_pkey");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("character varying");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Cases>(entity =>
            {
                entity.HasIndex(e => e.Amount)
                    .HasName("index_cases_on_amount");

                entity.HasIndex(e => e.CaseNo)
                    .HasName("index_cases_on_case_no");

                entity.HasIndex(e => e.CourtType)
                    .HasName("index_cases_on_court_type");

                entity.HasIndex(e => e.Description)
                    .HasName("index_cases_on_description");

                entity.HasIndex(e => e.DocketType)
                    .HasName("index_cases_on_docket_type");

                entity.HasIndex(e => e.FillingDate)
                    .HasName("index_cases_on_filling_date");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cases_id_seq'::regclass)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric");

                entity.Property(e => e.CaseNo)
                    .HasColumnName("case_no")
                    .HasColumnType("character varying");

                entity.Property(e => e.CaseType)
                    .HasColumnName("case_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.CaseUrl)
                    .HasColumnName("case_url")
                    .HasColumnType("character varying");

                entity.Property(e => e.CourtType)
                    .HasColumnName("court_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DocketType)
                    .HasColumnName("docket_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.FillingDate).HasColumnName("filling_date");

                entity.Property(e => e.Judge)
                    .HasColumnName("judge")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("character varying");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<Defendants>(entity =>
            {
                entity.ToTable("defendants");

                entity.HasIndex(e => e.Address)
                    .HasName("index_defendants_on_address");

                entity.HasIndex(e => e.FirstName)
                    .HasName("index_defendants_on_first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("index_defendants_on_last_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Attorney)
                    .HasColumnName("attorney")
                    .HasColumnType("character varying");

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<Plaintiffs>(entity =>
            {
                entity.ToTable("plaintiffs");

                entity.HasIndex(e => e.Address)
                    .HasName("index_plaintiffs_on_address");

                entity.HasIndex(e => e.FirstName)
                    .HasName("index_plaintiffs_on_first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("index_plaintiffs_on_last_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Attorney)
                    .HasColumnName("attorney")
                    .HasColumnType("character varying");

                entity.Property(e => e.CaseId).HasColumnName("case_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("schema_migrations_pkey");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
