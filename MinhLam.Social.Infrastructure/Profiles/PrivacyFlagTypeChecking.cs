using MinhLam.Social.Domain.Profiles;
using System;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class PrivacyFlagTypeChecking : IPrivacyFlagTypeChecking
    {
        public SocialContext context;

        public PrivacyFlagTypeChecking(SocialContext context)
        {
            this.context = context;
        }

        public bool ExistWithId(Guid id)
        {
            var privayFlagType = this.context.PrivacyFlagTypes.FirstOrDefault(x => x.Id == id);
            return privayFlagType != null;
        }
    }
}
