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
        return await _playerRepository.GetPlayer(id);
    }
    
    public async Task<Player> CreatePlayer(AddPlayerDto addPlayerDto)
    {
        Player newPlayer = _mapper.Map<Player>(addPlayerDto);
        return await _playerRepository.AddPlayer(newPlayer);
    }
    
    public async Task<Player> UpdatePlayer(Guid id, UpdatePlayerDto updatePlayerDto)
    {
        Player playerToUpdate = await GetPlayer(id);
        
        if (!string.IsNullOrWhiteSpace(updatePlayerDto.NickName))
            playerToUpdate.UpdateNickName(updatePlayerDto.NickName);

        if (!string.IsNullOrWhiteSpace(updatePlayerDto.Telephone))
            playerToUpdate.UpdateTelephone(updatePlayerDto.Telephone);
        
        return await _playerRepository.UpdatePlayer(playerToUpdate);
    }

    public async Task<Player> DeletePlayer(Guid id)
    {
        Player player = await GetPlayer(id);
        if (player.Team != null)
            throw new Exception($"Cannot delete Player '{player.NickName}' because player already belongs to team: {player.Team.Name}");
        
        return await _playerRepository.DeletePlayer(id);
    }
}