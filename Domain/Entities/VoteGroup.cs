namespace Domain.Entities;

public class VoteGroup
{
    public int Id { get; set; }
    public string GroupName { get; set; }
    public string GroupDescription { get; set; }
    public string Symbol { get; set; }
    public int VotesCount { get; set; }
    public ICollection<VoteGroup> Votes { get; set; }
}
