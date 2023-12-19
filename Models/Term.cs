using System.ComponentModel.DataAnnotations;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models;

[Table("Term")]
public class Term
{
    [PrimaryKey, AutoIncrement]
    [Column("TermId")]
    public string TermId
    { get; set; }

    [Column("TermName")]
    public string TermName
    { get; set; } = "Undefined Term Name";

    [Column("StartDate")]
    public DateTime StartDate
    { get; set; } = DateTime.Today;

    [Column("EndDate")]
    public DateTime EndDate
    { get; set; } = DateTime.Today.AddDays(90);

    [Column("Courses")]
    public List<string> Courses //List of CourseIds or CourseNames
    { get; set; } = [];


    public void ValidateTerm()
    {
        if (string.IsNullOrEmpty(TermName) || string.IsNullOrWhiteSpace(TermName))
        {
            throw new ValidationException("TermName cannot be null or empty");
        }

        if (StartDate > EndDate)
        {
            throw new ValidationException("StartDate cannot be after EndDate");
        }
    }

    #region Constructors

    public Term()
    {
    }

    public Term(string termName, DateTime startDate, DateTime endDate)
    {
        TermName = termName;
        StartDate = startDate;
        EndDate = endDate;
    }

    #endregion

    #region Add/Remove/Update

    public void TermModification(string operation, Term termBeingModified)
    {
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        _ = Helpers.WhatIsTheOperation(operation) switch
        {
            "insert" => InsertTerm(termBeingModified, db),
            "update" => UpdateTerm(termBeingModified, db),
            "delete" => DeleteTerm(termBeingModified, db),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    private async Task InsertTerm(Term term, SQLiteAsyncConnection db) =>
        await db.InsertAsync(term);
    private async Task UpdateTerm(Term term, SQLiteAsyncConnection db) =>
        await db.UpdateAsync(term);
    private async Task DeleteTerm(Term term, SQLiteAsyncConnection db) =>
        await db.DeleteAsync(term);

    public Task<List<Term>> GetTermsAsync()
    {
        var _ = new Connection();
        var db = _.GetAsyncConnection();
        return db.Table<Term>().ToListAsync();
    }

    private Task<Term> GetTermById(string termId, SQLiteAsyncConnection db)
    {
        return db.Table<Term>().Where(t => t.TermId == termId).FirstOrDefaultAsync();
    }

    #endregion
}