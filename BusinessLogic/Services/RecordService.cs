using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public bool AddRecord(Record record)
        {
            record.RecordDate = DateTime.Now;
            return _recordRepository.Add(record);
        }

        public bool EditRecord(Record record)
        {
            if (record == null) return false;

            return _recordRepository.Update(record);
        }

        public async Task<IndexViewModel> GetAllRecordsAsync()
        {
            return new IndexViewModel()
            {
                Query = "",
                Records = await _recordRepository.GetAllAsync()
            };
        }

        public Task<List<Record>> GetFilteredRecordsAsync(string query)
        {
            return _recordRepository.GetFilteredAsync(query);
        }

        public async Task<Record> GetRecordByIdAsync(int id)
        {
            return await _recordRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveRecord(int id)
        {
            var record = await _recordRepository.GetByIdAsync(id);

            if (record == null) return false;

            return _recordRepository.Delete(record);
        }
    }
}
