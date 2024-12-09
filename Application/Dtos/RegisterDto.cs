namespace Application.Dtos;

public class RegisterDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string Address { get; set; }
}
