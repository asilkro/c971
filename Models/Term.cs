using SQLite;

namespace CourseTracker.Models
{
    [Table("Term")]
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        [Column("Term_Guid")]
        public string Term_Guid
        { get; set; }

        [Column("Term_Title")]
        public string Term_Title
        { get; set; } = "Undefined Term Title";

        [Column("Term_Start")]
        public DateTime Term_Start
        { get; set; } = DateTime.Today;

        [Column("Term_End")]
        public DateTime Term_End
        { get; set; } = DateTime.Today.AddDays(90);
    }
}