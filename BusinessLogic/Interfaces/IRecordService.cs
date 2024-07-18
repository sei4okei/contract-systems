using BusinessLogic.Models;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecordService
    {
        Task<IndexViewModel> GetAllRecordsAsync();
        Task<Record> GetRecordByIdAsync(int id);
        Task<List<Record>> GetFilteredRecordsAsync(string query);
        bool EditRecord(Record record);
        Task<bool> RemoveRecord(int id);
        bool AddRecord(Record record);
    }
}
