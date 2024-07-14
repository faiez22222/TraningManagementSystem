namespace CourseManagementService.Model
{
    public class DailyTask
    {
        public int Id { get; set; } 
        public DateOnly Day {  get; set; }  
        public string TaskDescription { get; set; } 
        public int CourseCalendarId { get; set; }     
        
    }
}
