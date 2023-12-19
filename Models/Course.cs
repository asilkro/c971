using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Maui.Core;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models
{
    [Table("Courses")]
    public class Course
    {
        #region Properties / Columns

        [PrimaryKey, NotNull]
        [Column("CourseId")] public string CourseId { get; set; }

        [Column("TermId")] public string TermId { get; set; } = "Placeholder";

        [Column("CourseName")] public string CourseName { get; set; } = "Placeholder";

        [Column("StartDate")] public DateTime StartDate { get; set; } = DateTime.Today.Date;

        [Column("EndDate")] public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);

        [Column("Status")] public string Status { get; set; } = "Undefined";

        [Column("InstructorName")] public string InstructorName { get; set; } = "Placeholder CI";

        [Column("InstructorEmail")] public string InstructorEmail { get; set; } = "placeholder@wgu.edu";

        [Column("InstructorPhone")] public string InstructorPhone { get; set; } = "555-555-1234";

        [Column("Notes")] public string Notes { get; set; } = "Placeholder Course Notes";
        [Column("CourseNotifications")] public bool CourseNotifications { get; set; } = true;


        #endregion

        #region Methods / Validation

        public bool CourseStatusIsValid(string status)
        {
            var result = status switch
            {
                "planned" => true,
                "inProgress" => true,
                "awaitingEvaluation" => true,
                "completed" => true,
                _ => false
            };
            return result;
        }

        public void ValidateCourse()
        {
            if (!CourseStatusIsValid(this.Status))
            {
                throw new ValidationException("Status is not valid");
            }
            if (string.IsNullOrEmpty(CourseId))
            {
                throw new ValidationException("CourseId cannot be null or empty");
            }

            if (string.IsNullOrEmpty(CourseName))
            {
                throw new ValidationException("CourseName cannot be null or empty");
            }

            if (StartDate > EndDate)
            {
                throw new ValidationException("StartDate cannot be after EndDate");
            }

            if (EndDate < StartDate)
            {
                throw new ValidationException("EndDate cannot be before StartDate");
            }

            if (string.IsNullOrEmpty(InstructorName))
            {
                throw new ValidationException("InstructorName cannot be null or empty");
            }

            if (string.IsNullOrEmpty(InstructorEmail))
            {
                throw new ValidationException("InstructorEmail cannot be null or empty");
            }

            if (string.IsNullOrEmpty(InstructorPhone))
            {
                throw new ValidationException("InstructorPhone cannot be null or empty");
            }

            if (string.IsNullOrEmpty(Notes))
            {
                throw new ValidationException("Notes cannot be null or empty");
            }

            if (!Helpers.EmailIsValid(InstructorEmail))
            {
                throw new ValidationException("InstructorEmail is not valid");
            }
        }

        #endregion

        #region Add/Remove/Update

        public void CourseModification(string operation, Course courseBeingOperated)
        {
            var conn = new Connection();
            var db = conn.GetAsyncConnection();
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    _ = InsertCourse(courseBeingOperated, db);
                    break;
                case "update":
                    _ = UpdateCourse(courseBeingOperated, db);
                    break;
                case "delete":
                    _ = DeleteCourse(courseBeingOperated, db);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private async Task InsertCourse(Course course, SQLiteAsyncConnection db) =>
            await db.InsertAsync(course);

        private async Task UpdateCourse(Course course, SQLiteAsyncConnection db) =>
            await db.UpdateAsync(course);

        private async Task DeleteCourse(Course course, SQLiteAsyncConnection db) =>
            await db.DeleteAsync(course);


        #endregion

        private async Task<Course> GetCourseByIdAsync(string courseId, SQLiteAsyncConnection db)
        {
            return await db.Table<Course>().Where(c => c.CourseId == courseId).FirstOrDefaultAsync();
        }
    }
}