using Microsoft.AspNetCore.Mvc;
using ManagerDashboardAPI.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BatchController : ControllerBase
{
    public ActionResult<IEnumerable<Batch>> GetBatches()
    {
        var batches = new List<Batch>
        {
            new Batch {BatchId = 1, CourseName = "Course A", StarDate = DateTime.Parse("2024-07-15"), EndDate = DateTime.Parse("2024-07-20"), Instructor = "Instructor 1"Status="Open"},
            new Batch {BatchId = 2, CourseName = "Course B", StarDate = DateTime.Parse("2024-08-01"), EndDate = DateTime.Parse("2024-08-05"), Instructor = "Instructor 2", Status="Open"}
        };
        return Ok(batches);
    }
}