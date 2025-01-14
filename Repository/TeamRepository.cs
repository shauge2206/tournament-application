using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Data;
using TournamentApp.Domain;
using TournamentApp.Interface.Team;
using TournamentApp.Model;

namespace TournamentApp.Repository;

public class TeamRepository : ITeamRepository
{

    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public TeamRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<List<Team>> GetTeams()
    {
        List<TeamModel> teamsEntities = await _dataContext.Teams.AsNoTracking()
            .Include(t => t.Players)
            .ToListAsync();

        return _mapper.Map<List<Team>>(teamsEntities);
    }

    public async Task<Team> GetTeam(Guid id)
    {
        TeamModel teamEntity = await GetTeamEntityByIdNoTracking(id);
        return _mapper.Map<Team>(teamEntity);
    }

    public async Task<Team> AddTeam(Team newTeam)
    {
        TeamModel newTeamEntity = _mapper.Map<TeamModel>(newTeam);

        await _dataContext.Teams.AddAsync(newTeamEntity);
        await _dataContext.SaveChangesAsync();

        return newTeam;
    }

    public async Task<Team> DeleteTeam(Guid id)
    {
        TeamModel teamEntityToDelete = await GetTeamEntityById(id);

        _dataContext.Teams.Remove(teamEntityToDelete);
        await _dataContext.SaveChangesAsync();

        return _mapper.Map<Team>(teamEntityToDelete);
    }

    public async Task<Team> UpdateTeam(Team updatedTeam)
    {
        TeamModel teamEntityToUpdate = await GetTeamEntityById(updatedTeam.TeamId);

        // Update individual properties or relationships without replacing the entire list
        foreach (var player in updatedTeam.Players)
        {
            var existingPlayer = teamEntityToUpdate.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer == null)
            {
                // Add new player
                teamEntityToUpdate.Players.Add(_mapper.Map<PlayerModel>(player));
            }
            else
            {
                // Update existing player properties (if needed)
                _mapper.Map(player, existingPlayer);
            }
        }
        
        await _dataContext.SaveChangesAsync();
        
        //Detaching to avoid tracking conflicts when updating Player aswell
        _dataContext.Entry(teamEntityToUpdate).State = EntityState.Detached;

        

        return updatedTeam;
    }

    public Task<Team> DeletePlayerFromTeam(Guid id, Player removedPlayer)
    {
        throw new NotImplementedException();
    }

    private async Task<TeamModel> GetTeamEntityById(Guid id)
    {
        return await _dataContext.Teams.FindAsync(id)
               ?? throw new KeyNotFoundException($"Team with ID {id} was not found.");
    }

    private async Task<TeamModel> GetTeamEntityByIdNoTracking(Guid id)
    {
        return await _dataContext.Teams.AsNoTracking()
                   .Include(t => t.Players)
                   .FirstOrDefaultAsync(t => t.TeamId == id)
               ?? throw new KeyNotFoundException($"Team with ID {id} was not found.");
    }
}