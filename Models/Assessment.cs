using System.ComponentModel.DataAnnotations;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models;

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

    [Column("RelatedCourseId")]
    public string RelatedCourseId
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

        if (string.IsNullOrEmpty(RelatedCourseId) || string.IsNullOrWhiteSpace(RelatedCourseId))
        {
            throw new ValidationException("RelatedCourseId cannot be null or empty");
        }
    }

    #region Constructors

    public Assessment()
    {
    }

    public Assessment(string assessmentName, string assessmentType, DateTime assessmentStartDate, DateTime assessmentEndDate,
        string relatedCourseId)
    {
        ValidateAssessment();
        AssessmentName = assessmentName;
        AssessmentType = assessmentType;
        AssessmentStartDate = assessmentStartDate;
        AssessmentEndDate = assessmentEndDate;
        RelatedCourseId = relatedCourseId;
    }

    #endregion


    #region Add/Remove/Update

    public void AssessmentModification(string operation, Assessment assessmentBeingOperated)
    {
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        _ = Helpers.WhatIsTheOperation(operation) switch
        {
            "insert" => InsertAssessment(assessmentBeingOperated, db),
            "update" => UpdateAssessment(assessmentBeingOperated, db),
            "delete" => DeleteAssessment(assessmentBeingOperated, db),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    public Task<List<Assessment>> GetAssessmentsAsync()
    {
        var db = new Connection().GetAsyncConnection();
        return db.Table<Assessment>().ToListAsync();
    }

    private async Task InsertAssessment(Assessment assessment, SQLiteAsyncConnection db) =>
        await db.InsertAsync(assessment);

    private async Task UpdateAssessment(Assessment assessment, SQLiteAsyncConnection db) =>
        await db.UpdateAsync(assessment);

    private async Task DeleteAssessment(Assessment assessment, SQLiteAsyncConnection db) =>
        await db.DeleteAsync(assessment);

    private Task<Assessment> GetAssessmentById(string assessmentId, SQLiteAsyncConnection db)
    {
        return db.Table<Assessment>().Where(a => a.AssessmentId == assessmentId).FirstOrDefaultAsync();
    }

    #endregion
}