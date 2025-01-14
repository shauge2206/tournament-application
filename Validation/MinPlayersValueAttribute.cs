using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Validation;

public class MinPlayersValueAttribute : ValidationAttribute
{
    private readonly int _minValue;

    public MinPlayersValueAttribute(int minValue)
    {
        _minValue = minValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int intValue && intValue >= _minValue)
            return new ValidationResult($"The minimum player count must be equal or greater than {_minValue}.");

        return ValidationResult.Success;
    }
}