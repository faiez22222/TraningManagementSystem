namespace CourseManagementService.Model
{
    public class CourseCalendar
    {
        public int Id { get; set; } 
        public int CourseId { get; set; }   
        public DateTime StartDate { get; set; } 
        public DateTime EndTime { get; set; }   
        public ICollection<DailyTask> DailyTasks { get; set; }  
    }
}
