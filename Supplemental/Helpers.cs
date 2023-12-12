﻿using System;
using System.Linq;
using System.Net.Mail;
using SQLitePCL;
using static CourseTracker.Models.Course;

namespace CourseTracker.Supplemental
{
    public class Helpers
    {
        private readonly char at = '@';
        private readonly char dot = '.';
        private readonly char space = ' ';

        public enum Operations
        {
            insert,
            update,
            delete
        }

        public Operations OperationType { get; set; } //TODO: Can this be removed?

        public static string WhatIsTheOperation(string input)
        {
            
            if (Enum.IsDefined(typeof(Operations), input))
            {
                var result = Enum.Parse<Operations>(input).ToString();
                return result;
            }
            throw new ArgumentException("Invalid operation type"); //TODO: Make a unit test to verify this is infallible.
        }


        public static bool EmailIsValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}