using MediatR;

namespace Application.Commands.Command;

internal class DeleteVoteGroupCommand : IRequest<bool>  
{
    public int GroupId { get; set; }
}
