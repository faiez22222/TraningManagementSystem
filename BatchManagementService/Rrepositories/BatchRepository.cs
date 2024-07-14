using BatchManagementService.Model;
using BatchManagementService.Rrepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly BatchManagementContext _context;

        public BatchRepository(BatchManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Batch>> GetBatchesAsync()
        {
            return await _context.Batches.Include(b => b.Enrollments).ToListAsync();
        }

        public async Task<Batch> GetBatchByIdAsync(int id)
        {
            return await _context.Batches.Include(b => b.Enrollments).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Batch> AddBatchAsync(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task<Batch> UpdateBatchAsync(Batch batch)
        {
            _context.Batches.Update(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task DeleteBatchAsync(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
