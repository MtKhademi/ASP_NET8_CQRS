using Application.Commands.Command;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.CommandHandler;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth,
            State = request.State,
            City = request.City,
            Address = request.Address,
            HasVoted = false,
            IsAuthorized = false
        };

        var result = _userManager.CreateAsync(user, request.Password).Result;
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Voter");
            return true;
        }
        return false;
    }
}
