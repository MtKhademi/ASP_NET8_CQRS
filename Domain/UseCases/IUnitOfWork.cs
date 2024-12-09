namespace Domain.UseCases;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IVoteRepository Votes { get; }
    IVoteGroupRepository VoteGroupRepository { get; }

    Task<int> CompleteAsync();
}
