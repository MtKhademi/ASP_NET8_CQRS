using Application.Commands.Command;
using MediatR;

namespace Application.Commands.CommandHandler;

internal class UpdateVoterAuthorizationCommandHandler : IRequestHandler<UpdateVoterAuthorizationCommand, bool>
{
    public Task<bool> Handle(UpdateVoterAuthorizationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
