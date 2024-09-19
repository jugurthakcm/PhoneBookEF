using System.Net.Mail;
using System.Text.RegularExpressions;

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

    internal static bool ValidatePhone(string phone)
    {
        const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        if (phone != null)
            return Regex.IsMatch(phone, motif);
        else
            return false;
    }
}
