using MinhLam.Social.Domain.Profiles;
using System;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class VisibilityChecking : IVisibilityChecking
    {
        private SocialContext context;

        public VisibilityChecking(SocialContext context)
        {
            this.context = context;
        }

        public bool ExistWithId(Guid id)
        {
            var visibility = this.context.Visibilities.FirstOrDefault(x => x.Id == id);
            return visibility != null;
        }
    }
}
