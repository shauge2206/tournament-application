using TournamentApp.DTO.Player;

namespace TournamentApp.DTO.Team;

public class TeamResponseDto
{
    public required string Name { get; init; }
    public int MaxPlayers { get; init; }
    public int MinPlayers { get; init; }
    public List<PlayerResponseDto> Players { get; init; } = new();
}