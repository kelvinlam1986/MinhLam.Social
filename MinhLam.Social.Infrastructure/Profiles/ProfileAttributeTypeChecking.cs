using MinhLam.Social.Domain.Profiles;
using System;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class ProfileAttributeTypeChecking : IProfileAttributeTypeChecking
    {
        private SocialContext context;

        public ProfileAttributeTypeChecking(SocialContext context)
        {
            this.context = context;
        }

        public bool ExistWithId(Guid id)
        {
            var profileAttributeType = this.context.ProfileAttributeTypes.Find(id);
            return profileAttributeType != null;
        }
    }
}
