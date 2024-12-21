using AutoMapper;
using TournamentApp.Domain;
using TournamentApp.DTO.Player;
using TournamentApp.Interface.Player;

namespace TournamentApp.Service;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    
    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<Player>> GetAllPlayers()
    {
        return await _playerRepository.GetPlayers();
    }

    public async Task<Player> GetPlayer(Guid id)
    {
        var player = await _playerRepository.GetPlayer(id);
        if (player == null)
        {
            throw new KeyNotFoundException($"Player with ID {id} was not found.");
        }
        
        return player;
    }
    
    public async Task<Player> CreatePlayer(AddPlayerDto addPlayerDto)
    {
        Player createdPlayer = _mapper.Map<Player>(addPlayerDto);
        return await _playerRepository.AddPlayer(createdPlayer);
    }
    
    public async Task<Player> UpdatePlayer(Guid id, Player updatePlayerDto)
    {
        Player playerToUpdate = await GetPlayer(id);
        
        if (!string.IsNullOrWhiteSpace(updatePlayerDto.NickName))
            playerToUpdate.UpdateNickName(updatePlayerDto.NickName);

        if (!string.IsNullOrWhiteSpace(updatePlayerDto.Telephone))
            playerToUpdate.UpdateTelephone(updatePlayerDto.Telephone);
        
        return await _playerRepository.UpdatePlayer(playerToUpdate);
    }

    public Task<Player> DeletePlayer(Guid id)
    {
        return _playerRepository.DeletePlayer(id);
    }
}