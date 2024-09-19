using System.Net.Mail;

namespace phonebookef.validation;

internal class Validation
{
    internal static bool ValidateEmail(string email)
    {
        var valid = true;

        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}
