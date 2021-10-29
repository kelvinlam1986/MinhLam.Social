using MinhLam.Social.Guide.Domain.Models;
using MinhLam.Social.Guide.Domain.Repositories;
using MinhLam.Social.Guide.Framework;
using MinhLam.Social.Guide.Infrastructure.Base;
using System.Linq;

namespace MinhLam.Social.Guide.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IRepositoryBase<User>, IUserRepository
    {
        public GuideContext dbContext;
        public UserRepository(GuideContext guideContext) : base(guideContext)
        {
        }

        public User ByUserName(string username)
        {
            return this.dbContext.Users.FirstOrDefault(x => x.UserName == username);
        }

        public bool Has(string username)
        {
            var user = ByUserName(username);
            return user != null;
        }
    }
}
