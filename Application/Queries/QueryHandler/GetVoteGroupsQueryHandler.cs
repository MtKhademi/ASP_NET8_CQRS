using Application.Queries.Query;
using Domain.Entities;
using Domain.UseCases;
using MediatR;

namespace Application.Queries.QueryHandler;

internal class GetVoteGroupsQueryHandler : IRequestHandler<GetVoteGroupsQuery, IEnumerable<VoteGroup>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVoteGroupsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<VoteGroup>> Handle(GetVoteGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.VoteGroupRepository.GetAllAsync();
    }
}
