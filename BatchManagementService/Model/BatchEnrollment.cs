using System.Text.Json.Serialization;

namespace BatchManagementService.Model
{
    public class BatchEnrollment
    {
        public int Id { get; set; } 
        public int BatchId { get; set; }    
        public int EmployeeId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnrollmentStatus Status { get; set; }    
    }
    public enum EnrollmentStatus
    {
        Pending,    
        Rejected ,
        Enrolled , 
        Accepted , 
    }

}
