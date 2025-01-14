namespace TournamentApp.Interface;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}