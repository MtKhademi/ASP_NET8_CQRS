using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string Address { get; set; }
    public bool? HasVoted { get; set; }
    public bool? IsAuthorized { get; set; }
}
