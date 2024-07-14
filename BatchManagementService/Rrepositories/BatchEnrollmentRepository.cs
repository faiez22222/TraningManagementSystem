using BatchManagementService.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Repositories
{
    public class BatchEnrollmentRepository : IBatchEnrollmentRepository
    {
        private readonly BatchManagementContext _context;

        public BatchEnrollmentRepository(BatchManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatchEnrollment>> GetBatchEnrollmentsAsync()
        {
            return await _context.BatchEnrollments.ToListAsync();
        }

        public async Task<BatchEnrollment> GetBatchEnrollmentByIdAsync(int id)
        {
            return await _context.BatchEnrollments.FindAsync(id);
        }

        public async Task<BatchEnrollment> AddBatchEnrollmentAsync(BatchEnrollment batchEnrollment)
        {
            _context.BatchEnrollments.Add(batchEnrollment);
            await _context.SaveChangesAsync();
            return batchEnrollment;
        }

        public async Task<BatchEnrollment> UpdateBatchEnrollmentAsync(BatchEnrollment batchEnrollment)
        {
            _context.BatchEnrollments.Update(batchEnrollment);
            await _context.SaveChangesAsync();
            return batchEnrollment;
        }

        public async Task DeleteBatchEnrollmentAsync(int id)
        {
            var batchEnrollment = await _context.BatchEnrollments.FindAsync(id);
            if (batchEnrollment != null)
            {
                _context.BatchEnrollments.Remove(batchEnrollment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
