using System;
using System.Linq;
using MinhLam.Social.Domain.Profiles;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(SocialContext dbContext) : base(dbContext)
        {
        }

        public Profile GetCurrentProfileIncludeAttributes(Guid id)
        {
            return DbContext.Profiles.Include("ProfileAttributes").FirstOrDefault(x => x.Id == id);
        }
    }
}
