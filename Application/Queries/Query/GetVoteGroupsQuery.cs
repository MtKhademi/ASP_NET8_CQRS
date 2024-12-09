using Domain.Entities;
using MediatR;

namespace Application.Queries.Query;

internal class GetVoteGroupsQuery : IRequest<IEnumerable<VoteGroup>>
{
}
