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
        //TODO: This shouldn't be used for anything, but it's here because the table needs a primary key.

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

        public void CourseModification(string operation, Instructor instructorBeingOperated)
        {
            switch (Helpers.WhatIsTheOperation(operation))
            {
                case "insert":
                    InsertInstructor(instructorBeingOperated);
                    break;
                case "update":
                    UpdateInstructor(instructorBeingOperated);
                    break;
                case "delete":
                    DeleteInstructor(instructorBeingOperated);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private void InsertInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        private void UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        private void DeleteInstructor(Instructor instructor)
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
