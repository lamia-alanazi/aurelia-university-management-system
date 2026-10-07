using System.Data.Entity;

namespace lamia12771.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}