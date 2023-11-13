using System;
using SQLite;

namespace c971.Classes
{
    [Table("Course")]
    public class Course
    {

        [PrimaryKey, NotNull]
        [Column("Course_Guid")]
        public Guid Course_Guid
        { get; set; }

        [Column("Course_Id")]
        public string Course_Id
        { get; set; } = "Undefined";

        [Column("Course_Title")]
        public string Course_Title
        { get; set; } = "Placeholder";

        [Column("Course_Start")]
        public DateTime Course_Start
        { get; set; } = DateTime.Today.Date;

        [Column("Course_End")]
        public DateTime Course_End
        { get; set; } = DateTime.Today.AddDays(30);

        [Column("Course_Status")]
        public CourseStatuses Course_Status
        { get; set; } = CourseStatuses.undefined;

        [Column("CI_Name")]
        public string CI_Name
        { get; set; } = "Placeholder CI";

        [Column("CI_Email")]
        public string CI_Email
        { get; set; } = "placeholder@wgu.edu";

        [Column("CI_Phone")]
        public string CI_Phone
        { get; set; } = "555-555-1234";

        public string Course_Notes
        { get; set; } = "Placeholder Course Notes";

        public enum CourseStatuses
        {
            undefined,
            planned,
            in_progress,
            awaiting_evaluation,
            completed,
            dropped,
        }
    }
}