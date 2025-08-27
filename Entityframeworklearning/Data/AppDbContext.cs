using Microsoft.EntityFrameworkCore;

namespace Entityframeworklearning.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
    }
}
