using Application.Commands.Command;
using Domain.Entities;
using Domain.UseCases;
using MediatR;

namespace Application.Commands.CommandHandler;

internal class CreateVoterGroupCommandHandler : IRequestHandler<CreateVoterGroupCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVoterGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CreateVoterGroupCommand request, CancellationToken cancellationToken)
    {
        var voterGroup = new VoteGroup
        {
            GroupName = request.GroupName,
            GroupDescription = request.GroupDescription,
            //GroupImageUrl = request.GroupImageUrl,
            VotesCount = 0
        };

        await _unitOfWork.VoteGroupRepository.AddAsync(voterGroup);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
}
