namespace TournamentApp.Interface.Player;

public interface IPlayerRepository
{
    Task<List<Domain.Player>> GetPlayers();
    Task<Domain.Player> GetPlayer(Guid id);
    Task<Domain.Player> AddPlayer(Domain.Player newPlayer);
    Task<Domain.Player> UpdatePlayer(Domain.Player updatedPlayer);
    Task<Domain.Player> DeletePlayer(Guid id);
}