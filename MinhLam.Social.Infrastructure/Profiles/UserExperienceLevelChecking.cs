using MinhLam.Social.Domain.Profiles;
using System;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class UserExperienceLevelChecking : IUserExperienceLevelChecking
    {
        public SocialContext context;

        public UserExperienceLevelChecking(SocialContext context)
        {
            this.context = context;
        }

        public bool ExistWithId(Guid id)
        {
            var levelOfExperience = context.LevelOfExperiences.Find(id);
            return levelOfExperience != null;
        }
    }
}
