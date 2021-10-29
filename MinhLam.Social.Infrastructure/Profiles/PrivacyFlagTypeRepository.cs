using MinhLam.Social.Domain.Profiles;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class PrivacyFlagTypeRepository : IPrivacyFlagTypeRepository
    {
        private readonly SocialContext context;

        public PrivacyFlagTypeRepository(SocialContext context)
        {
            this.context = context;
        }

        public List<PrivacyFlagType> GetMandatoryList()
        {
            var mandatoryNames = new List<string>()
            {
                PrivacyFlagType.IM,
                PrivacyFlagType.AccountInfo,
                PrivacyFlagType.TankInfo
            };

            return this.context.PrivacyFlagTypes
                    .Where(x => mandatoryNames.Contains(x.FieldName)).ToList();
        }
    }
}
