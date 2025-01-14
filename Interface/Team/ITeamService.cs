using TournamentApp.DTO.Team;

namespace TournamentApp.Interface.Team;

public interface ITeamService
{
    Task<List<Domain.Team>> GetAllTeams();
    Task<Domain.Team> GetTeam(Guid id);
    Task<Domain.Team> CreateTeam(AddTeamDto addTeamDto);
    Task<Domain.Team> DeleteTeam(Guid id);
    Task<Domain.Team> AddPlayerToTeam(Guid teamId, Guid playerId);
    Task<Domain.Team> RemovePlayerFromTeam(Guid teamId, Guid playerId);
}