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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(s => s.StudentId);


                e.Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();


                e.Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .IsUnicode(false);


                e.Property(s => s.RegisteredOn)
                    .IsRequired();

                e.Property(s => s.Birthday)
                    .IsRequired(false);

            });



            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(c => c.CourseId);

                e.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode();

                e.Property(c => c.Description)
                    .IsUnicode();

                e.Property(c => c.StartDate)
                    .IsRequired();

                e.Property(c => c.EndDate)
                    .IsRequired();

                e.Property(c => c.Price)
                    .IsRequired();

            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.HasKey(r => r.ResourseId);

                e.Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

                e.Property(r => r.Url)
                    .IsUnicode(false)
                    .IsRequired();

                e.Property(r => r.ResourceType)
                    .IsRequired(true);

                e.Property(r => r.CourseId)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Homework>(e =>
            {
                e.ToTable("HomeworkSubmissions");
                
                e.HasKey(h => h.HomeworkId);

                e.Property(h => h.Content)
                    .IsUnicode(false)
                    .IsRequired();

                e.Property(h => h.ContentType)
                    .IsRequired();

                e.Property(h => h.SubmissionTime)
                    .IsRequired();

                e.Property(h => h.StudentId)
                    .IsRequired();

                e.Property(h => h.CourseId)
                    .IsRequired();
            });


            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(sc => new { sc.StudentId, sc.CourseId });

                e.HasOne(sc => sc.Student)
                    .WithMany(sc => sc.CourseEnrollments)
                    .HasForeignKey(c => c.CourseId)
                    .HasConstraintName("FK_StudentCourse_Students");

                e.HasOne(sc => sc.Course)
                    .WithMany(sc => sc.StudentsEnrolled)
                    .HasForeignKey(c => c.StudentId)
                    .HasConstraintName("FK_StudentCourse_Course");
            });

        }
    }
}
