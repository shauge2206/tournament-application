using System.ComponentModel.DataAnnotations;

namespace TournamentApp.DTO.Team;

public class AddTeamDto
{
    [Required(ErrorMessage = "Team name is required.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Team name must be between 3 and 20 characters.")]
    public required string Name { get; init; }
    
    [Required(ErrorMessage = "Maximum players is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Maximum players must be a positive number.")]
    public required int MaxPlayers { get; init; }
    
    [Required(ErrorMessage = "Minimum players is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Minimum players must be a positive number.")]
    public required int  MinPlayers { get; init; }
}