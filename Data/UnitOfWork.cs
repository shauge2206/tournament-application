using Microsoft.EntityFrameworkCore.Storage;
using TournamentApp.Interface;

namespace TournamentApp.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        if (_transaction != null)
        {
            _transaction.Rollback(); // Automatically rolls back if not committed
            _transaction.Dispose();
        }
    }
}