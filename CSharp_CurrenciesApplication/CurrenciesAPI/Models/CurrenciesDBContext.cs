using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CurrenciesAPI.Models
{
    public partial class CurrenciesDBContext : DbContext
    {
        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((_, __) => true, true)
        });

        public CurrenciesDBContext()
        {
        }

        public CurrenciesDBContext(DbContextOptions<CurrenciesDBContext> options)
            : base(options)
        {
        }

        //DbSet = tables
        public virtual DbSet<Colours> Colours { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<CurrenciesTypes> CurrenciesTypes { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CurrenciesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colours>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Currencies)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Currencies_ToCountries");
            });

            modelBuilder.Entity<CurrenciesTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Currencies_Types");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.HasOne(d => d.Currencies)
                    .WithMany(p => p.CurrenciesTypes)
                    .HasForeignKey(d => d.CurrenciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Currencies_Types_ToCurrencies");

                entity.HasOne(d => d.Type)
                    .WithOne(p => p.CurrenciesTypes)
                    .HasForeignKey<CurrenciesTypes>(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Currencies_Types_ToTypes");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
