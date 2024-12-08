using Domain.Entities;
using Domain.UseCases;
using Infrastraucture.Data;

namespace Infrastraucture.Implementations;

public class VoteGroupRepository : Repository<VoteGroup>, IVoteGroupRepository
{
    public VoteGroupRepository(VotingContext context) : base(context)
    {
    }
}
