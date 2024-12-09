using Domain.Entities;
using Domain.UseCases;
using Infrastraucture.Data;

namespace Infrastraucture.Implementations;

public class VoteRepository : Repository<VoteGroup>, IVoteRepository
{
    public VoteRepository(VotingContext context) : base(context)
    {
    }
}