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

        public void AssessmentModification(string operation, Assessment assessmentBeingOperated)
        {
            var db = Constants.GetAsyncConnection();
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    _ = InsertAssessment(assessmentBeingOperated, db);
                    break;
                case "update":
                    _ = UpdateAssessment(assessmentBeingOperated, db);
                    break;
                case "delete":
                    _ = DeleteAssessment(assessmentBeingOperated, db);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        public async Task<List<Assessment>> GetAssessmentsAsync()
        {
            var db = Constants.GetAsyncConnection();
            return await db.Table<Assessment>().ToListAsync();
        }

        private async Task InsertAssessment(Assessment assessment, SQLiteAsyncConnection db) =>
            await db.InsertAsync(assessment);
        
        private async Task UpdateAssessment(Assessment assessment, SQLiteAsyncConnection db) => 
            await db.UpdateAsync(assessment);

        private async Task DeleteAssessment(Assessment assessment, SQLiteAsyncConnection db) =>
            await db.DeleteAsync(assessment);

        private async Task<Assessment> GetAssessmentById(string assessmentId, SQLiteAsyncConnection db)
        {
            return await db.Table<Assessment>().Where(a => a.AssessmentId == assessmentId).FirstOrDefaultAsync();
        }

        #endregion
    }
}