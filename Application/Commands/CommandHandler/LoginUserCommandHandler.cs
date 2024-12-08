using Application.Commands.Command;
using Domain.Entities;
using Domain.UseCases;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.CommandHandler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null || !(user.IsAuthorized ?? false))
        {
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe,
            lockoutOnFailure: false);
        return result.Succeeded;

    }
}
