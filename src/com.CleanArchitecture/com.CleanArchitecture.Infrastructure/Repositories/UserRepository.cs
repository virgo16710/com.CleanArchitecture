using com.CleanArchitecture.Domain.Users;

namespace com.CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class UserRepository :Repository<User ,UserId>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
