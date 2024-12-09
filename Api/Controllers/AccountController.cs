using Application.Commands.Command;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var command = new RegisterUserCommand
        {
            Email = registerDto.Email,
            Password = registerDto.Password,
            FullName = registerDto.FullName,
            DateOfBirth = registerDto.DateOfBirth,
            State = registerDto.State,
            City = registerDto.City,
            Address = registerDto.Address
        };
        var result = await _mediator.Send(command);
        if (result)
            return Ok();
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Login(RegisterDto registerDto)
    {
        var command = new LoginUserCommand
        {
            Email = registerDto.Email,
            Password = registerDto.Password,
        };
        var result = await _mediator.Send(command);
        if (result)
            return Ok();
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Logout(RegisterDto registerDto)
    {
        var result = await _mediator.Send(new LogoutUserCommand());
        if (result)
            return Ok();
        return BadRequest();
    }
}
