using Microsoft.AspNetCore.Mvc;
using ManagerDashboardAPI.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentRequestController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<EnrollmentRequest>> GetRequests()
    {
        var requests = new List<EnrollementRequest>
        {
            new EnrollmentRequest {RequestId = 101, ParticipantName = "Participant A", DesireBatch = " Course A", RequestDate = DateTime.Parse("2024-07-10"), Status = "Pending" },
            new EnrollmentRequest {RequestId = 102, ParticipantName = "Participant B", DesireBatch = " Course B", RequestDate = DateTime.Parse("2024-07-10"), Status = "Pending" },

        };
        return Ok(requests);
    }
    [HttpPost("accept/{id}")]
    public ActionResult Accept (int id)
    {
        return NoContent();
    }
    [HttpPost("reject/{id}")]
    public ActionResult Reject(int id)
    {
        return NoContent();
    }
}