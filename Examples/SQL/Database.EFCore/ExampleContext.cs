using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<BookCategoryEntity> Summaries { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.ToTable("book");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Category);
            });

            modelBuilder.Entity<BookCategoryEntity>(entity =>
            {
                entity.ToTable("book_category");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<BookCategoryEntity>().HasData(new BookCategoryEntity { Id = 1, Category = "Novel" });
            modelBuilder.Entity<BookCategoryEntity>().HasData(new BookCategoryEntity { Id = 2, Category = "Adventure" });
            modelBuilder.Entity<BookCategoryEntity>().HasData(new BookCategoryEntity { Id = 3, Category = "Fantasy" });
            modelBuilder.Entity<BookCategoryEntity>().HasData(new BookCategoryEntity { Id = 4, Category = "History" });
            
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 1, 
                BookCategoryEntity = 1,
                Rating = 4.6,
                Name = "Eugene Onegin"
            });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 2, 
                BookCategoryEntity = 2,
                Rating = 4.3,
                Name = "Robinson Crusoe"
            });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 3, 
                BookCategoryEntity = 3,
                Rating = 4.8,
                Name = "Lord of the Rings: The Fellowship of The Ring"
            });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 4, 
                BookCategoryEntity = 4,
                Rating = 4.5,
                Name = "Comparative biographies"
            });
            
            //modelBuilder.Entity<WeatherEntity>().OwnsOne(p => p.Summary).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Code = "Chill" });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
