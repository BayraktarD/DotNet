
using Microsoft.EntityFrameworkCore;

namespace CatalogOnline_ClassLibrary.EntityModels
{
    public class SchoolDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<Mark> Marks{ get; set; }

        public SchoolDbContext()
        {
            Database.EnsureCreated();
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
    : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Proiecte\\GitHub\\DotNet\\Proiect - Catalog Online\\CatalogOnline-ClassLibrary\\Database\\SchoolDatabase.mdf\";Integrated Security=True");
        }

    }
}
