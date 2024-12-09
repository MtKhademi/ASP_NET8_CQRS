using Application.Commands.Command;
using Domain.UseCases;
using MediatR;

namespace Application.Commands.CommandHandler;

internal class UpdateVoteGroupCommandHandler : IRequestHandler<UpdateVoteGroupCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVoteGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateVoteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = _unitOfWork.VoteGroupsRepository.GetById(request.GroupId);
        if (group == null)
        {
            return false;
        }

        group.GroupName = request.GroupName;
        group.GroupDescription = request.GroupDescription;

        _unitOfWork.VoteGroupsRepository.Update(group);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
}
