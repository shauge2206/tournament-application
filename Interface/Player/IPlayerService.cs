using TournamentApp.DTO.Player;

namespace TournamentApp.Interface.Player;

public interface IPlayerService
{
    Task<List<Domain.Player>> GetAllPlayers();
    Task<Domain.Player> GetPlayer(Guid id);
    Task<Domain.Player> CreatePlayer(AddPlayerDto addPlayerDto);
    Task<Domain.Player> UpdatePlayer(Guid id, UpdatePlayerDto updatePlayerDto);
    Task<Domain.Player> DeletePlayer(Guid id);
}