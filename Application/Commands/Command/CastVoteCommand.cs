using MediatR;

namespace Application.Commands.Command;

internal class CastVoteCommand : IRequest<bool>
{
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
