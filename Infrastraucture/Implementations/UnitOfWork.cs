using Domain.UseCases;
using Infrastraucture.Data;

namespace Infrastraucture.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly VotingContext _context;

    public UnitOfWork(VotingContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Votes = new VoteRepository(_context);
        VoteGroups = new VoteGroupRepository(_context);
    }

    public IUserRepository Users { get; private set; }

    public IVoteRepository Votes { get; private set; }

    public IVoteGroupRepository VoteGroups { get; private set; }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
