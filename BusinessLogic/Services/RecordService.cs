using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            return _recordRepository.Add(record);
        }

        public async Task<List<Record>> GetAllRecordsAsync()
        {
            return await _recordRepository.GetAllAsync();
        }

        public async Task<Record> GetRecordByIdAsync(int id)
        {
            return await _recordRepository.GetByIdAsync(id);
        }

        public bool RemoveRecord(Record record)
        {
            return _recordRepository.Delete(record);
        }
    }
}
