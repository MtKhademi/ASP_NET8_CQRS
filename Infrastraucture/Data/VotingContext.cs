using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastraucture.Data;

public class VotingContext : IdentityDbContext<ApplicationUser>
{
    public VotingContext(DbContextOptions<VotingContext> options) : base(options)
    {
    }

    public DbSet<VoteGroup> VoteGroups { get; set; }
    public DbSet<Vote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Vote>()
            .HasOne(v => v.VouteGroup)
            .WithMany(g => g.VoteRepository)
            .HasForeignKey(v => v.GroupId);
    }
}
