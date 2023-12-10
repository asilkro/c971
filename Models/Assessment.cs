using System.ComponentModel.DataAnnotations;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models
{
    [Table("Assessment")]
    public class Assessment
    {
        public enum AssessmentType
        {
            PerformanceAssessment,
            ObjectiveAssessment
        }

        [PrimaryKey, AutoIncrement]
        [Column("AssessmentId")]
        public string AssessmentId
        { get; set; }

        [Column("AssessmentTitle")]
        public string AssessmentTitle
        { get; set; } = "Undefined";

        [Column("AssessmentType")]
        public AssessmentType Type
        { get; set; }

        [Column("AssessmentStart")]
        public DateTime StartDate
        { get; set; } = DateTime.Today;

        [Column("AssessmentEnd")]
        public DateTime EndDate
        { get; set; } = DateTime.Today.AddDays(30);

        [Column("CourseId")]
        public string CourseId
        { get; set; }

        public void ValidateAssessment()
        {
            if (string.IsNullOrEmpty(AssessmentTitle) || string.IsNullOrWhiteSpace(AssessmentTitle))
            {
                throw new ValidationException("AssessmentTitle cannot be null or empty");
            }

            if (StartDate > EndDate)
            {
                throw new ValidationException("StartDate cannot be after EndDate");
            }

            if (string.IsNullOrEmpty(CourseId) || string.IsNullOrWhiteSpace(CourseId))
            {
                throw new ValidationException("Related CourseId cannot be null or empty");
            }
        }

        #region Constructors

        public Assessment()
        {
        }

        public Assessment(string assessmentTitle, AssessmentType assessmentType, DateTime startDate, DateTime endDate,
            string courseId)
        {
            ValidateAssessment();
            AssessmentTitle = assessmentTitle;
            Type = assessmentType;
            StartDate = startDate;
            EndDate = endDate;
            CourseId = courseId;
        }

        #endregion


        #region Add/Remove/Update

        public void CourseModification(string operation, Assessment assessmentBeingOperated)
        {
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    InsertAssessment(assessmentBeingOperated);
                    break;
                case "update":
                    UpdateAssessment(assessmentBeingOperated);
                    break;
                case "delete":
                    DeleteAssessment(assessmentBeingOperated);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private void InsertAssessment(Assessment assessment)
        {
            throw new NotImplementedException();
        }

        private void UpdateAssessment(Assessment assessment)
        {
            throw new NotImplementedException();
        }

        private void DeleteAssessment(Assessment assessment)
        {
            throw new NotImplementedException();
        }


        #endregion

        private Task GetInstructorByIdAsync(string courseId)
        {
            throw new NotImplementedException();
        }
    }
}