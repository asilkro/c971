using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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

        [Column("Title")] public string Title { get; set; } = "Placeholder";

        [Column("StartDate")] public DateTime StartDate { get; set; } = DateTime.Today.Date;

        [Column("EndDate")] public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);

        [Column("Status")] public CourseStatuses Status { get; set; } = CourseStatuses.undefined;

        [Column("InstructorName")] public string InstructorName { get; set; } = "Placeholder CI";

        [Column("InstructorEmail")] public string InstructorEmail { get; set; } = "placeholder@wgu.edu";

        [Column("InstructorPhone")] public string InstructorPhone { get; set; } = "555-555-1234";

        [Column("Notes")] public string Notes { get; set; } = "Placeholder Course Notes";

        public enum CourseStatuses
        {
            undefined,
            planned,
            inProgress,
            awaitingEvaluation,
            completed,
            dropped,
        }

        #endregion

        #region Methods / Validation

        public void ValidateCourse()
        {
            if (string.IsNullOrEmpty(CourseId))
            {
                throw new ValidationException("CourseId cannot be null or empty");
            }

            if (string.IsNullOrEmpty(Title))
            {
                throw new ValidationException("Title cannot be null or empty");
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
            var db = Constants.GetAsyncConnection();
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    InsertCourse(courseBeingOperated, db);
                    break;
                case "update":
                    UpdateCourse(courseBeingOperated, db);
                    break;
                case "delete":
                    DeleteCourse(courseBeingOperated, db);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private async task InsertCourse(Course course, SQLiteAsyncConnection db) =>
            await db.InsertAsync(course);

        private async task UpdateCourse(Course course, SQLiteAsyncConnection db) =>
            await db.UpdateAsync(course);

        private async task DeleteCourse(Course course, SQLiteAsyncConnection db) =>
            await db.DeleteAsync(course);


        #endregion

        private async Task<Course> GetCourseByIdAsync(string courseId, SQLiteAsyncConnection db)
        {
            return await db.Table<Course>().Where(c => c.CourseId == courseId).FirstOrDefaultAsync();
        }
    }
}