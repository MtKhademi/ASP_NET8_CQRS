using Application.Commands.Command;
using Domain.Entities;
using Domain.UseCases;
using MediatR;

namespace Application.Commands.CommandHandler;

internal class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, bool>
{
    public readonly IUnitOfWork _unitOfWork;

    public CastVoteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CastVoteCommand request, CancellationToken cancellationToken)
    {
        var voteGroup = _unitOfWork.VoteGroupRepository.GetById(request.GroupId);
        if (voteGroup == null)
        {
            return false;
        }

        var user = _unitOfWork.UserRepository.GetById(request.UserId);
        if (user == null || !(user.IsAuthorized ?? false))
        {
            return false;
        }

        var existingVote = (await _unitOfWork.VoteRepository.GetAllAsync(
            v => v.UserId == request.UserId && v.GroupId == request.GroupId)).FirstOrDefault();

        await _unitOfWork.VoteRepository.AddAsync(new VoteGroup
        {
            UserId = request.UserId,
            GroupId = request.GroupId,
            VoteDate = DateTime.Now
        });

        if (voteGroup != null)
        {
            voteGroup.VotesCount++;
            var result = await _unitOfWork.CompleteAsync();
            return result > 0;
        }
        return false;
    }
}
