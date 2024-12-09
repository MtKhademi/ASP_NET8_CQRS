using MediatR;

namespace Application.Commands.Command;

internal class UpdateVoteGroupCommand : IRequest<bool>
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public string GroupDescription { get; set; }
}
