using System.ComponentModel.DataAnnotations;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models
{
    [Table("Assessment")]
    public class Assessment
    {

        [PrimaryKey, AutoIncrement]
        [Column("AssessmentId")]
        public string AssessmentId
        { get; set; }

        [Column("AssessmentName")]
        public string AssessmentName
        { get; set; } = "Undefined";

        [Column("AssessmentType")]
        public string AssessmentType
        { get; set; } = "ObjectiveAssessment";

        [Column("AssessmentStartDate")]
        public DateTime AssessmentStartDate
        { get; set; } = DateTime.Today;

        [Column("AssessmentEndDate")]
        public DateTime AssessmentEndDate
        { get; set; } = DateTime.Today.AddDays(30);

        [Column("CourseId")]
        public string CourseId
        { get; set; }

        public void ValidateAssessment()
        {
            if (string.IsNullOrEmpty(AssessmentName) || string.IsNullOrWhiteSpace(AssessmentName))
            {
                throw new ValidationException("AssessmentName cannot be null or empty");
            }

            if (AssessmentStartDate > AssessmentEndDate)
            {
                throw new ValidationException("AssessmentStartDate cannot be after AssessmentEndDate");
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

        public Assessment(string assessmentName, AssessmentType assessmentType, DateTime assessmentStartDate, DateTime assessmentEndDate,
            string courseId)
        {
            ValidateAssessment();
            AssessmentName = assessmentName;
            Type = assessmentType;
            AssessmentStartDate = assessmentStartDate;
            AssessmentEndDate = assessmentEndDate;
            CourseId = courseId;
        }

        #endregion


        #region Add/Remove/Update

        public void AssessmentModification(string operation, Assessment assessmentBeingOperated)
        {
            var conn = new Connection();
            var db = conn.GetAsyncConnection();
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
            var db = new Connection().GetAsyncConnection();
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