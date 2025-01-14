using System.ComponentModel.DataAnnotations;
using TournamentApp.Domain;

namespace TournamentApp.Validation;

[AttributeUsage(AttributeTargets.Class)]
public class PlayersRangeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not Team team)
            return new ValidationResult("Invalid object type for PlayersRangeValidation.");

        if (team.MinPlayers > team.MaxPlayers)
            return new ValidationResult("Minimum players cannot be greater than maximum players.");

        return ValidationResult.Success;
    }
}