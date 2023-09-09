using Microsoft.EntityFrameworkCore;

namespace Lab12Ex1.Models
{
    public class SchoolDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public SchoolDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Proiecte\GitHub\DotNet\Lab11Ex1\Lab11Ex1_ClassLibrary\SchoolDatabase.mdf;Integrated Security=True");
        }
    }
}
