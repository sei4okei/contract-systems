using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class PasswordContext : DbContext
    {
        public DbSet<Record> Record { get; set; }

        public PasswordContext(DbContextOptions<PasswordContext> options)
            : base(options)
        {

        }
    }
}
