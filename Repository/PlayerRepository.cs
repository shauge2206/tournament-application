using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Data;
using TournamentApp.Domain;
using TournamentApp.Interface.Player;
using TournamentApp.Model;

namespace TournamentApp.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    
    
    public PlayerRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    
    public async Task<List<Player>> GetPlayers()
    {
        List<PlayerModel> playerEntities = await _dataContext.Players.AsNoTracking()
            .Include(p => p.Team)
            .ToListAsync();
        
        return _mapper.Map<List<Player>>(playerEntities);
    }

    public async Task<Player> GetPlayer(Guid id)
    {
        PlayerModel playerEntity = await GetPlayerEntityByIdNoTracking(id);
        
        return _mapper.Map<Player>(playerEntity);
    }

    public async Task<Player> AddPlayer(Player newPlayer)
    {
        PlayerModel newPlayerEntity = _mapper.Map<PlayerModel>(newPlayer);
        
        await _dataContext.Players.AddAsync(newPlayerEntity);
        await _dataContext.SaveChangesAsync();
        
        return _mapper.Map<Player>(newPlayerEntity);
    }

    public async Task<Player> UpdatePlayer(Player updatedPlayer)
    {
        PlayerModel playerEntityToUpdate = await GetPlayerEntityById(updatedPlayer.Id);
        
        if (playerEntityToUpdate.NickName != updatedPlayer.NickName)
            playerEntityToUpdate.NickName = updatedPlayer.NickName;
        if (playerEntityToUpdate.Telephone != updatedPlayer.Telephone)
            playerEntityToUpdate.Telephone = updatedPlayer.Telephone;
        if (playerEntityToUpdate.TeamId != updatedPlayer.Team?.TeamId)
            playerEntityToUpdate.TeamId = updatedPlayer.Team?.TeamId;
        
        await _dataContext.SaveChangesAsync();
        
        //Detaching to avoid tracking conflicts when updating Team aswell
        _dataContext.Entry(playerEntityToUpdate).State = EntityState.Detached;
        
        return _mapper.Map<Player>(playerEntityToUpdate);
    }
    
    public async Task<Player> DeletePlayer(Guid id)
    {
        PlayerModel playerEntityToDelete = await GetPlayerEntityById(id);
 
        _dataContext.Players.Remove(playerEntityToDelete);
        await _dataContext.SaveChangesAsync();
        
        return _mapper.Map<Player>(playerEntityToDelete);
    }

    private async Task<PlayerModel> GetPlayerEntityById(Guid id)
    {
        return await _dataContext.Players.FindAsync(id) 
               ?? throw new KeyNotFoundException($"Player with ID {id} was not found.");
    }
    
    private async Task<PlayerModel> GetPlayerEntityByIdNoTracking(Guid id)
    {
        return await _dataContext.Players
                   .Include(p => p.Team)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(p => p.Id == id)
               ?? throw new KeyNotFoundException($"Player with ID {id} was not found.");
    }
    
}