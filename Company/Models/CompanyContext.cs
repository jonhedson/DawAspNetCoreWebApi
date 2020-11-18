using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Information> Information { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityInformation> CityInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Configuration
            modelBuilder.Entity<Country>()
                .HasKey(s => s.PId);

            //Property Configurations Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasColumnName("CountryName")
                      .HasDefaultValue("USA")
                      .IsRequired();

                entity.Property(e => e.AddedOn)
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

            });

            modelBuilder.Entity<Country>().Ignore(e => e.Population);

            //Property Configurations Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //Property Configurations Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            //Property Configurations City
            modelBuilder.Entity<City>()
                .HasOne(e => e.CityInformation)
                .WithOne(e => e.City)
                .HasForeignKey<City>(e => e.CityInformationId);

            modelBuilder.Entity<City>()
                .HasOne(e => e.Country)
                .WithMany(e => e.City)
                .HasForeignKey(e => e.FKCountry)
                .OnDelete(DeleteBehavior.Cascade);

            //Property Configurations TeacherStudent
            modelBuilder.Entity<TeacherStudent>()
                        .HasKey(t => new { t.StudentId, t.TeacherId });

            modelBuilder.Entity<TeacherStudent>()
                        .HasOne(t => t.Student)
                        .WithMany(t => t.TeacherStudent)
                        .HasForeignKey(t => t.StudentId);

            modelBuilder.Entity<TeacherStudent>()
                        .HasOne(t => t.Teacher)
                        .WithMany(t => t.TeacherStudent)
                        .HasForeignKey(t => t.TeacherId);


        }
    }

    
}
