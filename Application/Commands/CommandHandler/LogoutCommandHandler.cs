using Application.Commands.Command;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.CommandHandler;

internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
{
    private readonly SignInManager<ApplicationUser> _singInManager;

    public LogoutCommandHandler(SignInManager<ApplicationUser> singInManager)
    {
        _singInManager = singInManager;
    }

    public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _singInManager.SignOutAsync();
        return true; 
    }
}
