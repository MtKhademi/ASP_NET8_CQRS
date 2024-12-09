using Domain.UseCases;
using Infrastraucture.Data;

namespace Infrastraucture.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly VotingContext _context;

    public UnitOfWork(VotingContext context)
    {
        _context = context;
        UserRepository = new UserRepository(_context);
        VoteRepository = new VoteRepository(_context);
        VoteGroupRepository = new VoteGroupRepository(_context);
    }

    public IUserRepository UserRepository { get; private set; }

    public IVoteRepository VoteRepository { get; private set; }

    public IVoteGroupRepository VoteGroupRepository { get; private set; }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
