using TournamentApp.Model;

namespace TournamentApp;

public class TournamentModel
{
    public required String name { get; init; }
    public required String GameCode { get; init; }
    public required List<TeamModel> Teams { get; init; }
    public required int VippsNummber { get; init; }
    
}