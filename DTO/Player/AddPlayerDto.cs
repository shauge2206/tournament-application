using System.ComponentModel.DataAnnotations;
using TournamentApp.Validation;

namespace TournamentApp.DTO.Player;

public class AddPlayerDto
{
    [Required(ErrorMessage = "Nickname is required.")]                           
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Nickname must be between 3 and 20 characters.")]                              
    public required string NickName { get; init; }
    
    [DigitsOnly(ErrorMessage = "Telephone must can only contain numbers.")]
    public string? Telephone { get; init; }
}