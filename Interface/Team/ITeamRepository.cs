namespace TournamentApp.MapperProfile;

public interface ITeamRepository
{
    Task<List<TeamModel>> GetTeams();
    Task<TeamModel?> GetTeam(int id);
}