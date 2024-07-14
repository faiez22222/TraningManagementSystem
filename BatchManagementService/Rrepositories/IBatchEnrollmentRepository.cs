using BatchManagementService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatchManagementService.Repositories
{
    public interface IBatchEnrollmentRepository
    {
        Task<IEnumerable<BatchEnrollment>> GetBatchEnrollmentsAsync();
        Task<BatchEnrollment> GetBatchEnrollmentByIdAsync(int id);
        Task<BatchEnrollment> AddBatchEnrollmentAsync(BatchEnrollment batchEnrollment);
        Task<BatchEnrollment> UpdateBatchEnrollmentAsync(BatchEnrollment batchEnrollment);
        Task DeleteBatchEnrollmentAsync(int id);
    }
}
