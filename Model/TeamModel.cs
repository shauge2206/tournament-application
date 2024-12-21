using TournamentApp.Model;

namespace TournamentApp;

public class TeamModel
{
    public required List<PlayerModel> players { get; init; }
    public required string name { get; init; }
    public required int MaxPlayers { get; init; }
    public required int MinPlayers { get; init; }
}