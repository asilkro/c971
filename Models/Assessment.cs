using SQLite;

namespace CourseTracker.Models
{
    [Table("Assessment")]
    public class Assessment
    {
        public enum Type
        {
            PerformanceAssessment,
            ObjectiveAssessment,
            Undefined,
        }

        [PrimaryKey, AutoIncrement]
        [Column("Assessment_Guid")]
        public Guid Assessment_Guid
        { get; set; }

        [Column("AssessmentTitle")]
        public string Assessment_Title
        { get; set; } = "Undefined";

        [Column("AssessmentType")]
        public Type AssessmentType
        { get; set; } = Type.Undefined;

        [Column("AssessmentStart")]
        public DateTime StartDate
        { get; set; } = DateTime.Today;

        [Column("AssessmentEnd")]
        public DateTime EndDate
        { get; set; } = DateTime.Today.AddDays(30);
    }
}