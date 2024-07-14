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
            modelBuilder.Entity<Course>()
                .HasOne(c => c.CourseCalendar)
                .WithOne()
                .HasForeignKey<CourseCalendar>(cc => cc.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Configure delete behavior

            // CourseCalendar to DailyTask relationship (one-to-many)
            modelBuilder.Entity<CourseCalendar>()
                .HasMany(cc => cc.DailyTasks)
                .WithOne()
                .HasForeignKey(dt => dt.CourseCalendarId)
                .OnDelete(DeleteBehavior.Cascade); // Configure delete behavior

            base.OnModelCreating(modelBuilder);
        }


    }
}
