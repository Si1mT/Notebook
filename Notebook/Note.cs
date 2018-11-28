using SQLite;

namespace Notebook
{
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Content { get; set; }
        //public string Title { get; set; }
    }
}