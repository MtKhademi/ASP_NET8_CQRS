using MediatR;

namespace Application.Commands.Command;

public class CreateVoterGroupCommand : IRequest<bool>
{
    public string GroupName { get; set; }
    public string GroupDescription { get; set; }
    public string GroupImageUrl { get; set; }
}
