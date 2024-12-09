using Application.Queries.Query;
using Domain.Entities;
using Domain.UseCases;
using MediatR;

namespace Application.Queries.QueryHandler;

internal class VoteGroupByIdQueryHandler : IRequestHandler<VoteGroupByIdQuery, VoteGroup>
{
    private readonly IUnitOfWork _unitOfWork;

    public VoteGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<VoteGroup> Handle(VoteGroupByIdQuery request, CancellationToken cancellationToken)
    {
        return _unitOfWork.VoteGroupRepository.GetById(request.GroupId);
    }
}
