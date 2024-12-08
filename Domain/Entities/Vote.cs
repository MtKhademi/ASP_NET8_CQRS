using System.Security.Principal;

namespace Domain.Entities;

public class Vote
{
    public int VoteId { get; set; }
    public string UserId { get; set; }
    public int GroupId { get; set; }
    public DateTime VoteDate { get; set; } 
    public ApplicationUser User { get; set; }
    public VoteGroup VouteGroup { get; set; } 
}
