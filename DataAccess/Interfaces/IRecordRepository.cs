using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IRecordRepository
    {
        Task<List<Record>> GetAllAsync();
        Task<Record> GetByIdNoTrackingAsync(int id);
        Task<Record> GetByIdAsync(int id);
        Task<List<Record>> GetFilteredAsync(string query);
        bool Add(Record record);
        bool Update(Record record);
        bool Delete(Record record);
        bool Save();
    }
}
