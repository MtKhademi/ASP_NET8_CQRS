namespace Domain.UseCases;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IVoteRepository Votes { get; }
    IVoteGroupRepository VoteGroupsRepository { get; }

    Task<int> CompleteAsync();
}
