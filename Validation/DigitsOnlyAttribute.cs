using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TournamentApp.Validation;

public class DigitsOnlyAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        if (value is string input && string.IsNullOrEmpty(input))
            return ValidationResult.Success;

        const string pattern = @"^\d*$";
        if (value is string inputValue && Regex.IsMatch(inputValue, pattern))
            return ValidationResult.Success;

        return new ValidationResult("The field must contain only digits or be empty.");
    }
}   