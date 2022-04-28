using Microsoft.EntityFrameworkCore;

namespace DBAtsiskaitymas.Contexts
{
    public class UniversityContext : DbContext
    { 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=localhost;Database=UniversityDB;Trusted_Connection=true;");
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().HasMany(x => x.Lectures).WithMany(x => x.Students);
        //    modelBuilder.Entity<Lecture>().HasMany(x=>x.Departments).WithMany(x => x.Lectures);

        //}
    }
}
