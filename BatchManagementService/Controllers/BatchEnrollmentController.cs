using BatchManagementService.Model;
using BatchManagementService.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BatchEnrollmentController : ControllerBase
    {
        private readonly IBatchEnrollmentRepository _batchEnrollmentRepository;

        public BatchEnrollmentController(IBatchEnrollmentRepository batchEnrollmentRepository)
        {
            _batchEnrollmentRepository = batchEnrollmentRepository;
        }

        /// <summary>
        /// Gets all batch enrollments.
        /// </summary>
        /// <returns>A list of batch enrollments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchEnrollment>>> GetBatchEnrollments()
        {
            return Ok(await _batchEnrollmentRepository.GetBatchEnrollmentsAsync());
        }

        /// <summary>
        /// Gets a specific batch enrollment by ID.
        /// </summary>
        /// <param name="id">The ID of the batch enrollment to retrieve.</param>
        /// <returns>The requested batch enrollment.</returns>
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

        /// <summary>
        /// Creates a new batch enrollment.
        /// </summary>
        /// <param name="batchEnrollment">The batch enrollment to create.</param>
        /// <returns>The created batch enrollment.</returns>
        [HttpPost]
        public async Task<ActionResult<BatchEnrollment>> PostBatchEnrollment(BatchEnrollment batchEnrollment)
        {
            var createdBatchEnrollment = await _batchEnrollmentRepository.AddBatchEnrollmentAsync(batchEnrollment);
            return CreatedAtAction(nameof(GetBatchEnrollment), new { id = createdBatchEnrollment.Id }, createdBatchEnrollment);
        }

        /// <summary>
        /// Updates an existing batch enrollment.
        /// </summary>
        /// <param name="id">The ID of the batch enrollment to update.</param>
        /// <param name="batchEnrollment">The updated batch enrollment data.</param>
        /// <returns>No content if successful.</returns>
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

        /// <summary>
        /// Deletes a specific batch enrollment by ID.
        /// </summary>
        /// <param name="id">The ID of the batch enrollment to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatchEnrollment(int id)
        {
            await _batchEnrollmentRepository.DeleteBatchEnrollmentAsync(id);
            return NoContent();
        }
    }
}
