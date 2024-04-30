using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace InitialProject.Validation
{
    public class NotEmptyTextBox : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                string pattern = @"\d";
                string pattern2 = @"[0-9.]";

                // Check if the input string contains any digit
                bool containsNumbersOrCharacters = Regex.IsMatch(s, pattern) || Regex.IsMatch(s, pattern2);

                if (s != String.Empty)
                {
                    return new ValidationResult(true, null);
                }

                return new ValidationResult(false, "Please enter a valid double value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }

        }

    }
    public class EmptyCheckBoxRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Izaberite period.");

            }
            else
            {
                return new ValidationResult(true, null);

            }
            return new ValidationResult(false, "Unknown error occured.");

        }
    }
}
