using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class PasswordContext : DbContext
    {
        public DbSet<Record> Record { get; set; }     

        public PasswordContext(DbContextOptions<PasswordContext> options)
            :base(options)
        {
             
        }
    }
}
