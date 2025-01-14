namespace TournamentApp.Interface.Team;

public interface ITeamRepository
{
    Task<List<Domain.Team>> GetTeams();
    Task<Domain.Team> GetTeam(Guid id);
    Task<Domain.Team> AddTeam(Domain.Team team);
    Task<Domain.Team> UpdateTeam(Domain.Team team);
    Task<Domain.Team> DeleteTeam(Guid id);
}