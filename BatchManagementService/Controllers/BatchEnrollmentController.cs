using BatchManagementService.Model;
using BatchManagementService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchEnrollmentController : ControllerBase
    {
        private readonly IBatchEnrollmentRepository _batchEnrollmentRepository;

        public BatchEnrollmentController(IBatchEnrollmentRepository batchEnrollmentRepository)
        {
            _batchEnrollmentRepository = batchEnrollmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchEnrollment>>> GetBatchEnrollments()
        {
            return Ok(await _batchEnrollmentRepository.GetBatchEnrollmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchEnrollment>> GetBatchEnrollment(int id)
        {
            var batchEnrollment = await _batchEnrollmentRepository.GetBatchEnrollmentByIdAsync(id);
            if (batchEnrollment == null)
            {
                return NotFound();
            }
            return Ok(batchEnrollment);
        }

        [HttpPost]
        public async Task<ActionResult<BatchEnrollment>> PostBatchEnrollment(BatchEnrollment batchEnrollment)
        {
            var createdBatchEnrollment = await _batchEnrollmentRepository.AddBatchEnrollmentAsync(batchEnrollment);
            return CreatedAtAction(nameof(GetBatchEnrollment), new { id = createdBatchEnrollment.Id }, createdBatchEnrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatchEnrollment(int id, BatchEnrollment batchEnrollment)
        {
            if (id != batchEnrollment.Id)
            {
                return BadRequest();
            }
            await _batchEnrollmentRepository.UpdateBatchEnrollmentAsync(batchEnrollment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatchEnrollment(int id)
        {
            await _batchEnrollmentRepository.DeleteBatchEnrollmentAsync(id);
            return NoContent();
        }
    }
}
