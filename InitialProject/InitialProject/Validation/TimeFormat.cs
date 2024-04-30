using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace InitialProject.Validation;

public class TimeFormat: ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        try
        {
            var s = value as string;

            string pattern = @"^([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$";

            // Check if the input string matches the pattern
            bool isValid = Regex.IsMatch(s, pattern);

            if (isValid)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Please enter a valid date.");
        }
        catch
        {
            return new ValidationResult(false, "Unknown error occured.");

        }
    }
}