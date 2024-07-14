using BatchManagementService.Model;

namespace BatchManagementService.Rrepositories
{
    public interface IBatchRepository
    {
        Task<IEnumerable<Batch>> GetBatchesAsync();
        Task<Batch> GetBatchByIdAsync(int id);
        Task<Batch> AddBatchAsync(Batch batch);
        Task<Batch> UpdateBatchAsync(Batch batch);
        Task DeleteBatchAsync(int id);
    }
}
