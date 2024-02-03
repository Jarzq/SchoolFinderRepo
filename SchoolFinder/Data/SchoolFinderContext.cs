using Microsoft.EntityFrameworkCore;
using SchoolFinder.models;
using SchoolFinder.Models;

namespace SchoolFinder.Data
{
    public class SchoolfinderContext : DbContext
    {
        public DbSet<SchoolEntity> SchoolEntities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SchoolEntitySubject> SchoolEntitySubjects { get; set; }
        public SchoolfinderContext(DbContextOptions<SchoolfinderContext> options) : base(options)
        {
        }

        public SchoolfinderContext()
        {
        }
    }
}
