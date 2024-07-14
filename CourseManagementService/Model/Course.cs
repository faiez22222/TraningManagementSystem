namespace CourseManagementService.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public  string CourseDescription { get; set; }  

        public int Duration { get; set; }   
        public CourseCalendar CourseCalendar { get; set; }  

    }
}
