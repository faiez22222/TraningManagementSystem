using CourseManagementService.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService
{
    public class CourseManagementContext : DbContext
    {
        public CourseManagementContext(DbContextOptions<CourseManagementContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCalendar> CourseCalendars {get ; set ;}
        public DbSet<DailyTask> DailyTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Course to CourseCalendar relationship (one-to-one, optional)
            base.OnModelCreating(modelBuilder);

            // Configuring the one-to-many relationship between Course and CourseCalendar
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseCalendars)
                .WithOne()
                .HasForeignKey(cc => cc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the one-to-many relationship between CourseCalendar and DailyTask
            modelBuilder.Entity<CourseCalendar>()
                .HasMany(cc => cc.DailyTasks)
                .WithOne()
                .HasForeignKey(dt => dt.CourseCalendarId)
                 .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
