using MediatR;

namespace Application.Commands.Command;

public class LoginUserCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}
