using BatchManagementService.Model;
using BatchManagementService.Repositories;
using BatchManagementService.Rrepositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchRepository _batchRepository;

        public BatchController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        /// <summary>
        /// Gets all batches.
        /// </summary>
        /// <returns>A list of batches.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            return Ok(await _batchRepository.GetBatchesAsync());
        }

        /// <summary>
        /// Gets a specific batch by ID.
        /// </summary>
        /// <param name="id">The ID of the batch to retrieve.</param>
        /// <returns>The requested batch.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _batchRepository.GetBatchByIdAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        /// <summary>
        /// Creates a new batch.
        /// </summary>
        /// <param name="batch">The batch to create.</param>
        /// <returns>The created batch.</returns>
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            var createdBatch = await _batchRepository.AddBatchAsync(batch);
            return CreatedAtAction(nameof(GetBatch), new { id = createdBatch.Id }, createdBatch);
        }

        /// <summary>
        /// Updates an existing batch.
        /// </summary>
        /// <param name="id">The ID of the batch to update.</param>
        /// <param name="batch">The updated batch data.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatch(int id, Batch batch)
        {
            if (id != batch.Id)
            {
                return BadRequest();
            }
            await _batchRepository.UpdateBatchAsync(batch);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific batch by ID.
        /// </summary>
        /// <param name="id">The ID of the batch to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            await _batchRepository.DeleteBatchAsync(id);
            return NoContent();
        }
    }
}
