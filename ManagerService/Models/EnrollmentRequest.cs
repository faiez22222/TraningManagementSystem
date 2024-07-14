using System;

public class EnrollmentRequest
{
    public int RequestId { get; set; }
    public string ParticipantName { get; set; }
    public string DesireBatch { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; }
}