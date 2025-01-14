using AutoMapper;
using TournamentApp.Domain;
using TournamentApp.DTO.Team;
using TournamentApp.Interface;
using TournamentApp.Interface.Player;
using TournamentApp.Interface.Team;
using TournamentApp.Model;

namespace TournamentApp.Service;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TeamService(ITeamRepository teamRepository, IMapper mapper, IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<Team>> GetAllTeams()
    {
        return await _teamRepository.GetTeams();
    }

    public Task<Team> GetTeam(Guid id)
    {
        return _teamRepository.GetTeam(id);
    }

    public Task<Team> CreateTeam(AddTeamDto addTeamDto)
    {
        Team newTeam = _mapper.Map<Team>(addTeamDto);
        
        return _teamRepository.AddTeam(newTeam);
    }
    
    public async Task<Team> AddPlayerToTeam(Guid teamId, Guid playerId)
    {
        Team team = await _teamRepository.GetTeam(teamId);
        
        Player player = await _playerRepository.GetPlayer(playerId);
        if (!string.IsNullOrEmpty(player.Team?.Name))
            throw new Exception($"Player already belongs to team: {player.Team.Name}");
        
        player.UpdateTeam(team);
        team.AssignTeamMember(player);
        
        await AddPlayerToTeamUnitOfWork(team, player);
        
        return await _teamRepository.GetTeam(teamId);
    }

    public async Task<Team> RemovePlayerFromTeam(Guid teamId, Guid playerId)
    {
        Player player = await _playerRepository.GetPlayer(playerId);
        player.RemoveFromTeam();
        
        Team team = await _teamRepository.GetTeam(teamId);
        team.RemoveTeamMember(player);
        
        await RemovePlayerFromTeamUnitOfWork(team, player);
        
        return await _teamRepository.GetTeam(teamId);
    }
    
    public async Task<Team> DeleteTeam(Guid id)
    {
        Team team = await _teamRepository.GetTeam(id);
        if (team.Players != null && team.Players.Count > 0)
            throw new InvalidOperationException("Cannot remove a team from the tournament if it still has players.");
        
        return await _teamRepository.DeleteTeam(id);
    }
    
    private async Task AddPlayerToTeamUnitOfWork(Team team, Player player)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _playerRepository.UpdatePlayer(player);
            await _teamRepository.UpdateTeam(team);
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
    
    private async Task RemovePlayerFromTeamUnitOfWork(Team team, Player player)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _playerRepository.UpdatePlayer(player);
            await _teamRepository.UpdateTeam(team);
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}