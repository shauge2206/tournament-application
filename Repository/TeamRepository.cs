using TournamentApp.MapperProfile;

namespace TournamentApp.Repository;

public class TeamRepository : ITeamRepository
{
    public Task<List<TeamModel>> GetTeams()
    {
        throw new NotImplementedException();
    }

    public Task<TeamModel?> GetTeam(int id)
    {
        throw new NotImplementedException();
    }
}