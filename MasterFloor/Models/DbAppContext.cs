using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasterFloor.Models
{
    class DbAppContext : DbContext
    {
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PartnerProduct> PartnersProducts { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Загружаем переменные окружения из .env файла
            Env.Load();
            Env.TraversePath().Load();

            // Читаем данные из .env
            string host = Env.GetString("DB_HOST", "localhost");
            string user = Env.GetString("DB_USER", "postgres");
            string password = Env.GetString("DB_PASSWORD", "root");
            string database = Env.GetString("DB_NAME", "master_floor");

            // Формируем строку подключения
            string connectionString = $"Host={host}; Username={user}; Password={password}; Database={database}";

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            modelBuilder.Entity<PartnerType>(entity =>
            {
                entity.ToTable("partner_type");

                entity.Property(e => e.Id).HasColumnName("partner_type_id");
                entity.Property(e => e.Name).HasColumnName("partner_type_name");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("partner");

                entity.Property(e => e.Id).HasColumnName("partner_id");
                entity.Property(e => e.Name).HasColumnName("partner_name");
                entity.Property(e => e.Director).HasColumnName("director");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Inn).HasColumnName("inn");
                entity.Property(e => e.Rating).HasColumnName("rating");
                entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");

                entity.HasOne(p => p.PartnerTypeEntity).WithMany(p => p.PartnerEntities);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.Id).HasColumnName("product_type_id");
                entity.Property(e => e.Name).HasColumnName("product_type_name");
                entity.Property(e => e.Coeficent).HasColumnName("product_type_coeficent");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("product_id");
                entity.Property(e => e.Name).HasColumnName("product_name");
                entity.Property(e => e.MinCost).HasColumnName("min_cost");
                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.HasOne(p => p.ProductTypeEntity).WithMany(p => p.ProductEntities);
            });

            modelBuilder.Entity<PartnerProduct>(entity =>
            {
                entity.ToTable("partner_product");

                entity.Property(e => e.Id).HasColumnName("partner_product_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.SaleDate).HasColumnName("sale_timestamp").HasConversion(dateTimeConverter);
                entity.Property(e => e.Quanity).HasColumnName("quantity");

                entity.HasOne(p => p.ProductEntity).WithMany(p => p.PartnerProductEntities);
                entity.HasOne(p => p.PartnerEntity).WithMany(p => p.PartnerProductEntities);
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.ToTable("material_type");

                entity.Property(e => e.Id).HasColumnName("material_type_id");
                entity.Property(e => e.Name).HasColumnName("material_type_name");
                entity.Property(e => e.ScrapRate).HasColumnName("material_type_scrap_rate");
            });
        }
    }
}
