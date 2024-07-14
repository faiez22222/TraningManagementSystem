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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            return Ok(await _batchRepository.GetBatchesAsync());
        }

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

        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            var createdBatch = await _batchRepository.AddBatchAsync(batch);
            return CreatedAtAction(nameof(GetBatch), new { id = createdBatch.Id }, createdBatch);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            await _batchRepository.DeleteBatchAsync(id);
            return NoContent();
        }
    }
}
