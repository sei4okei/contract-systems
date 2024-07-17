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
        Task<List<Record>> GetAllRecordsAsync();
        Task<Record> GetRecordByIdAsync(int id);
        bool RemoveRecord(Record record);
        bool AddRecord(Record record);
    }
}
