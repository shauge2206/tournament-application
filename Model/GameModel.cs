using TournamentApp.Enums;

namespace TournamentApp.Model;

public class GameModel
{
    public required int Result { get; init; }
    public required TournamentModel Tournament { get; init; }
    public required List<TeamModel> Team { get; init; }
    public required GameStatus Status { get; init; }
    public required TeamModel WinnerTeam { get; init; } 
}