using System.ComponentModel.DataAnnotations;
using TournamentApp.Validation;

namespace TournamentApp.Domain;

public class Player
{
    public Guid Id { get; set; }
    
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Nickname must be between 3 and 20 characters.")]
    public string NickName { get; set; }
    
    [DigitsOnly(ErrorMessage = "The field must contain only digits or be empty.")]
    public string? Telephone { get; set; }
    
    public Team? Team { get; set; }

    public void UpdateNickName(string newNickName)
    {
        if (string.IsNullOrWhiteSpace(newNickName))
            throw new ArgumentException($"'{nameof(newNickName)}' updated nick name cannot be null or whitespace", nameof(newNickName));
        
        NickName = newNickName;
    }

    public void UpdateTelephone(string newTelephone)
    {
        if (string.IsNullOrWhiteSpace(newTelephone))
            throw new ArgumentException($"'{nameof(newTelephone)}' updated telephone number cannot be null or whitespace", nameof(newTelephone));
        
        Telephone = newTelephone;
    }
    
    public void UpdateTeam(Team newTeam)
    {
        if (Team != null)
            throw new InvalidOperationException($"Player must leave current team: ${Team.Name} first");
        
        Team = newTeam ?? throw new ArgumentNullException(nameof(newTeam), "The new team cannot be null.");
    }

    public void RemoveFromTeam()
    {
        Team = null;
    }
}