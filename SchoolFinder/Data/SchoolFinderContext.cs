using Microsoft.EntityFrameworkCore;
using SchoolFinder.models;

namespace SchoolFinder.Data
{
    public class SchoolfinderContext : DbContext
    {
        public DbSet<JednostkaSzkolna> JednostkiSzkolne { get; set; }
        public SchoolfinderContext(DbContextOptions<SchoolfinderContext> options) : base(options)
        {
        }

        public SchoolfinderContext()
        {
        }
    }
}
