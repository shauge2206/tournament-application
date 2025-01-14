using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Validation;

public class MaxPlayersAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MaxPlayersAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int intValue && intValue <= _maxValue)
            return new ValidationResult($"The maximum player count must be equal or less than {_maxValue}.");

        return ValidationResult.Success;
    }
}