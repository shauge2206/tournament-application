
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentApp.Model;

public class TeamModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid TeamId { get; init; }
    
    public required List<PlayerModel> Players { get; set; } = new();
    
    public required string Name { get; init; }
    
    public required int MaxPlayers { get; init; }
    public required int MinPlayers { get; init; }
}