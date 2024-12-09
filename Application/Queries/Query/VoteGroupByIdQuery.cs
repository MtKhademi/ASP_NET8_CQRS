using Domain.Entities;
using MediatR;

namespace Application.Queries.Query;

internal class VoteGroupByIdQuery : IRequest<VoteGroup>
{
    public int GroupId { get; set; }
}
