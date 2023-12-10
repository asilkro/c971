using System;
using System.ComponentModel.DataAnnotations;
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
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    InsertCourse(courseBeingOperated);
                    break;
                case "update":
                    UpdateCourse(courseBeingOperated);
                    break;
                case "delete":
                    DeleteCourse(courseBeingOperated);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private void InsertCourse(Course course)
        {
            throw new NotImplementedException();
        }

        private void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        private void DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }


        #endregion

        private Task GetCourseByIdAsync(string courseId)
        {
            throw new NotImplementedException();
        }
    }
}