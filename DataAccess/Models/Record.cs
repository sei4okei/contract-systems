namespace DataAccess.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsEmail { get; set; } = false;
        public DateTime RecordDate { get; set; }
    }
}
