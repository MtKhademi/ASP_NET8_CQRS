using MediatR;

namespace Application.Commands.Command;

internal class UpdateVoterAuthorizationCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public bool IsAuthorized { get; set; }
}
