using Domain.Entities;
using Domain.UseCases;
using Infrastraucture.Data;

namespace Infrastraucture.Implementations;

internal class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    public UserRepository(VotingContext context) : base(context)
    {

    }
}