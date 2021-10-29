using MinhLam.Social.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class PrivacyFlagRepository : RepositoryBase<PrivacyFlag>, IPrivacyFlagRepository
    {
        public PrivacyFlagRepository(SocialContext dbContext) : base(dbContext)
        {
        }

        public List<PrivacyFlag> GetByProfileId(Guid profileId)
        {
            return this.DbContext.PrivacyFlags.Where(x => x.ProfileId == profileId).ToList();
        }
    }
}
