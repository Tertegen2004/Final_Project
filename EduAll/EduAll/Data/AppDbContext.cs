using Microsoft.EntityFrameworkCore;

namespace EduAll.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
