namespace TournamentApp.Model;

public class MatchEntryModel
{
    public required TeamModel Team { get; init; }
    public required GameModel Game { get; init; }
}