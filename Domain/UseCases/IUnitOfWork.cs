namespace Domain.UseCases;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IVoteRepository Votes { get; }
    IVoteGroupRepository VoteGroups { get; }

    Task<int> CompleteAsync();
}
