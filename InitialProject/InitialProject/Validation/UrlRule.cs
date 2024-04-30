using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace InitialProject.Validation;

public class UrlRule:ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        try
        {
            var s = value as string;
            string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";

            // Check if the input string matches the pattern
            bool matches=  Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);

            if (matches)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Please enter a valid url.");
        }
        catch
        {
            return new ValidationResult(false, "Unknown error occured.");
        }
    }
}