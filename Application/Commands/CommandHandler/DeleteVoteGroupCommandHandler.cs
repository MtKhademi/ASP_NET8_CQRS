using Application.Commands.Command;
using Domain.UseCases;
using MediatR;

namespace Application.Commands.CommandHandler;

internal class DeleteVoteGroupCommandHandler : IRequestHandler<DeleteVoteGroupCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVoteGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteVoteGroupCommand request, CancellationToken cancellationToken)
    {
        var voteGroup = _unitOfWork.VoteGroupRepository.GetById(request.GroupId);
        if (voteGroup == null)
        {
            return false;
        }
        _unitOfWork.VoteGroupRepository.Delete(voteGroup);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
}
