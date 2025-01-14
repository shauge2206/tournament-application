using System.ComponentModel.DataAnnotations;
using TournamentApp.Validation;

namespace TournamentApp.Domain;

[PlayersRangeValidation]
public class Team
{
    public Guid TeamId { get; set; }
    
    public List<Player> Players { get; set; } = new();
    
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Team name must be between 3 and 20 characters.")]
    public string Name { get; set; }
    
    [Required]
    public int MaxPlayers { get; set; }
    
    [Required]
    public int MinPlayers { get; set; }
    

    public void AssignTeamMember(Player player)
    {
        if (!CanAddPlayer())
            throw new InvalidOperationException($"'{nameof(MaxPlayers)}' Maximum players on team is reached");
        
        Players.Add(player);
    }

    public void RemoveTeamMember(Player playerToBeRemoved)
    {
        if (!CanRemovePlayer())
            throw new InvalidOperationException($"'{nameof(MinPlayers)}' Minimum players on team reached");
        
        Players.Remove(Players.First(p => p.Id == playerToBeRemoved.Id));
    }
    
    public bool CanAddPlayer()
    {
        return Players.Count < MaxPlayers;
    }

    public bool CanRemovePlayer()
    {
        return Players.Count > MinPlayers;
    }
}