using Aiub.Ums.Core.Entities;
using System.Data.Entity;

namespace Aiub.Ums.Infrastructure
{
    public class UmsDbContext: DbContext
    {
        public UmsDbContext() : base("UmsDbConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
