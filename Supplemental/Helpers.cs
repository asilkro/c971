using System;
using System.Linq;

namespace C971.Supplemental
{
    public class Helpers
    {
        private readonly char at = '@';
        private readonly char dot = '.';
        private readonly char space = ' ';


    public bool InsertToDb()
        {
            var inserted = false;

            //TODO: Unimplemented!
            return inserted;
        }
    public bool RemoveFromDb()
        {
            var removed = false;
            //TODO: Unimplemented!

            return removed;
        }
    public bool UpdateInDb()
        {
            var updated = false;
            //TODO: Unimplemented!

            return updated;
        }

    public static EmailMessage MakeEmail(string to, string? cc, string? bcc, string? subject, string body)
        {
            var email = new EmailMessage();
            {
                email.To.Add(to);
                email.Cc.Add(cc);
                email.Bcc.Add(bcc);
                email.Subject = subject;
                email.Body = body;
            }

            return email;
        }

    public static bool IsNullOrEmpty(string whatIsBeingChecked)
        {
            var result = false;
            
            if (whatIsBeingChecked != null) 
            {
                result = true;
            }

            return result;
        }

    public static bool CheckInput(string whatIsBeingChecked, string checkedAgainst)
        {
            var match = true;

            switch (checkedAgainst)
            {
                case "email":
                    //TODO: something
                    break;

                case "phone":
                    //TODO:
                    break;

                case "some other condition":
                    //TODO:
                    break;

            }

            return match;
        }
    }
}