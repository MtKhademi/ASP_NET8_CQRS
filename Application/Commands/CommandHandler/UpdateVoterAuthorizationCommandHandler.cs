using Application.Commands.Command;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.CommandHandler;

internal class UpdateVoterAuthorizationCommandHandler : IRequestHandler<UpdateVoterAuthorizationCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UpdateVoterAuthorizationCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(UpdateVoterAuthorizationCommand request, CancellationToken cancellationToken)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == request.UserId);
        if (user is null)
        {
            return false;
        }

        user.IsAuthorized = request.IsAuthorized;
        var result =await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }
}
