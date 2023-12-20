namespace CourseTracker.Supplemental;

public class Helpers
{
    public enum Operations
    {
        Insert,
        Update,
        Delete
    }

    public static string WhatIsTheOperation(string input)
    {
        if (!Enum.IsDefined(typeof(Operations), input))
            throw
                new ArgumentException(
                    "Invalid operation type");
        var result = Enum.Parse<Operations>(input).ToString();
        return result;
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