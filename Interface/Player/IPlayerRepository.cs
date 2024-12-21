using TournamentApp.Domain;
using TournamentApp.DTO;
using TournamentApp.DTO.Player;
using TournamentApp.Model;

namespace TournamentApp.Interface.Player;

public interface IPlayerRepository
{
    Task<List<Domain.Player>> GetPlayers();
    Task<Domain.Player?> GetPlayer(Guid id);
    Task<Domain.Player> AddPlayer(Domain.Player newPlayer);
    Task<Domain.Player> UpdatePlayer(Domain.Player updatedPlayer);
    Task<Domain.Player> DeletePlayer(Guid id);
}