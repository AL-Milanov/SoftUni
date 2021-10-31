using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> dbContext)
            : base(dbContext)
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SSC;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(e =>
            {
                e.Property(s => s.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.Property(r => r.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(e =>
            {
                e.Property(h => h.Content).IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(e => new { e.StudentId, e.CourseId });
            });
        }
    }
}
