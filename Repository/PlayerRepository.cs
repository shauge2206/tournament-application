using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Data;
using TournamentApp.Domain;
using TournamentApp.DTO.Player;
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
        List<PlayerModel> playersEntity = await _dataContext.Players.ToListAsync();
        return _mapper.Map<List<Player>>(playersEntity);
    }

    public async Task<Player?> GetPlayer(Guid id)
    {
        PlayerModel? playerEntity = await _dataContext.Players.FindAsync(id);
        return playerEntity != null ? _mapper.Map<Player>(playerEntity) : null;
    }

    public async Task<Player> AddPlayer(Player newPlayer)
    {
        PlayerModel newPlayerEntity = _mapper.Map<PlayerModel>(newPlayer);
        await _dataContext.Players.AddAsync(newPlayerEntity);
        await _dataContext.SaveChangesAsync();
        return newPlayer;
    }

    public async Task<Player> UpdatePlayer(Player updatedPlayer)
    {
        PlayerModel playerEntity = _mapper.Map<PlayerModel>(updatedPlayer);
        _dataContext.Players.Update(playerEntity);
        await _dataContext.SaveChangesAsync();

        return _mapper.Map<Player>(updatedPlayer);
    }
    
    public async Task<Player> DeletePlayer(Guid id)
    {
        PlayerModel? playerEntityToDelete = await _dataContext.Players.FindAsync(id);
        
        if (playerEntityToDelete == null) 
            throw new KeyNotFoundException($"Player with ID {id} was not found.");
 
        _dataContext.Players.Remove(playerEntityToDelete);
        await _dataContext.SaveChangesAsync();
        return _mapper.Map<Player>(playerEntityToDelete);  
    }  
    
}