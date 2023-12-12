using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseTracker.Supplemental;
using SQLite;

namespace CourseTracker.Models
{
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
            var db = Constants.GetAsyncConnection();
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    _ = InsertInstructor(instructorBeingOperated, db);
                    break;
                case "update":
                    _ = UpdateInstructor(instructorBeingOperated, db);
                    break;
                case "delete":
                    _ = DeleteInstructor(instructorBeingOperated, db);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private async task InsertInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
            await db.InsertAsync(instructor);

        private async task UpdateInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
            await db.UpdateAsync(instructor);

        private async task DeleteInstructor(Instructor instructor, SQLiteAsyncConnection db) =>
            await db.DeleteAsync(instructor);


        #endregion

        private async Task<Instructor> GetInstructorByIdAsync(string id, SQLiteAsyncConnection db)
        {
            return await db.Table<Instructor>().Where(i => i.InstructorId == id).FirstOrDefaultAsync();
        }
    }
}
