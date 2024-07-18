using DataAccess.Models;

namespace BusinessLogic.Models
{
    public class IndexViewModel
    {
        public string Query { get; set; } = "";
        public List<Record> Records { get; set; } = new List<Record>();
    }
}
