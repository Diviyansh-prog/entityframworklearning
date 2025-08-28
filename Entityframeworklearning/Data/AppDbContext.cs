using Microsoft.EntityFrameworkCore;

namespace Entityframeworklearning.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() { Id=1,Currency="INR",Description="Indian Ruppee"},
                new CurrencyType() { Id = 2, Currency = "USD", Description = "Us Dollar" },
                new CurrencyType() { Id = 3, Currency = "Dinar", Description = "Dinar" },
                new CurrencyType() { Id = 4, Currency = "Euro", Description = "Euro" });
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { Id = 2, Title = "English", Description = "English" },
                new Language() { Id = 3, Title = "Urdu", Description = "Urdu" },
                new Language() { Id = 4, Title = "Bengali", Description = "Bengali" });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

    }
}
