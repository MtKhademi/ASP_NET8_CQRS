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
        VoteGroupsRepository = new VoteGroupRepository(_context);
    }

    public IUserRepository Users { get; private set; }

    public IVoteRepository Votes { get; private set; }

    public IVoteGroupRepository VoteGroupsRepository { get; private set; }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
