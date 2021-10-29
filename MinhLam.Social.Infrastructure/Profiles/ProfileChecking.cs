using MinhLam.Social.Domain.Profiles;
using System;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class ProfileChecking : IProfileChecking
    {
        public SocialContext context;

        public ProfileChecking(SocialContext context)
        {
            this.context = context;
        }

        public bool ExistWithId(Guid id)
        {
            var profile = this.context.Profiles.FirstOrDefault(x => x.Id == id);
            return profile != null;
        }
    }
}
