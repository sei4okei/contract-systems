using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly PasswordContext _context;

        public RecordRepository(PasswordContext context)
        {
            _context = context;
        }

        public bool Add(Record record)
        {
            _context.Add(record);
            return Save();
        }

        public bool Delete(Record record)
        {
            _context.Remove(record);
            return Save();
        }

        public async Task<List<Record>> GetAllAsync()
        {
            return await _context.Record.ToListAsync();
        }

        public async Task<Record> GetByIdAsync(int id)
        {
            return await _context.Record
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Record> GetByIdNoTrackingAsync(int id)
        {
            return await _context.Record
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public bool Save() => _context.SaveChanges() > 0 ? true : false;

        public bool Update(Record record)
        {
            _context.Update(record);
            return Save();
        }
    }
}
