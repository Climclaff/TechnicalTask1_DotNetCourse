using Microsoft.EntityFrameworkCore;
using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<DbFile> DbFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TechincalTaskDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalogs");
                entity.HasKey(e => e.CatalogId);

                entity.Property(m => m.ParentCatalogId).IsRequired(false);

                entity.HasOne(d => d.ParentCatalog)
                .WithMany(p => p.ChildCatalogs)
                .HasForeignKey(d => d.ParentCatalogId)
                .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<DbFile>(entity =>
            {
                entity.ToTable("Files"); 
                entity.HasKey(e => e.FileId);

                entity.HasOne(d => d.Catalog)
                .WithMany(p => p.DbFiles)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.Cascade); 
            });

        }
    }
}
