using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class IndexViewModel
    {
        public string Query { get; set; } = "";
        public List<Record> Records { get; set; } = new List<Record>();
    }
}
