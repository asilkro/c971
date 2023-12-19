using System.ComponentModel.DataAnnotations;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models;

[Table("Instructor")]
public class Instructor
{
    [PrimaryKey, AutoIncrement]
    [Column("InstructorId")]
    public string InstructorId
    { get; set; }
    //This shouldn't be used for anything, but it's here
    //because the table needs a primary key.

    [Column("InstructorName")]
    public string InstructorName
    { get; set; } = "Undefined Instructor Name";

    [Column("InstructorEmail")]
    public string InstructorEmail
    { get; set; } = "undefined@wgu.edu";

    [Column("InstructorPhone")]
    public string InstructorPhone
    { get; set; } = "555-555-1234";

    [Column("CourseId")]
    public string CourseId
    { get; set; } = "Undefined Course ID";

    public void ValidateInstructor()
    {
        if (string.IsNullOrEmpty(InstructorName))
        {
            throw new ValidationException("InstructorName cannot be null or empty");
        }

        if (string.IsNullOrEmpty(InstructorEmail))
        {
            throw new ValidationException("InstructorEmail cannot be null or empty");
        }

        if (!Supplemental.Helpers.EmailIsValid(InstructorEmail))
        {
            throw new ValidationException("InstructorEmail is not a valid email address");
        }

        if (string.IsNullOrEmpty(InstructorPhone))
        {
            throw new ValidationException("InstructorPhone cannot be null or empty");
        }
    }

    #region Constructors

    public Instructor()
    {
    }

    public Instructor(string instructorName, string instructorEmail, string instructorPhone)
    {
        ValidateInstructor();
        InstructorName = instructorName;
        InstructorEmail = instructorEmail;
        InstructorPhone = instructorPhone;
    }

    #endregion

    #region Add/Remove/Update

    public void InstructorModification(string operation, Instructor instructorBeingOperated)
    {
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        _ = Helpers.WhatIsTheOperation(operation) switch
        {
            "insert" => InsertInstructor(instructorBeingOperated, db),
            "update" => UpdateInstructor(instructorBeingOperated, db),
            "delete" => DeleteInstructor(instructorBeingOperated, db),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    private static async Task InsertInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
        await db.InsertAsync(instructor);

    private static async Task UpdateInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
        await db.UpdateAsync(instructor);

    private static async Task DeleteInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
        await db.DeleteAsync(instructor);


    #endregion

    private Task<Instructor> GetInstructorByIdAsync(string id, SQLiteAsyncConnection db)
    {
        return db.Table<Instructor>().Where(i => i.InstructorId == id).FirstOrDefaultAsync();
    }
}