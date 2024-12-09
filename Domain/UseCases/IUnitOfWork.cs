namespace Domain.UseCases;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IVoteRepository VoteRepository { get; }
    IVoteGroupRepository VoteGroupRepository { get; }

    Task<int> CompleteAsync();
}
