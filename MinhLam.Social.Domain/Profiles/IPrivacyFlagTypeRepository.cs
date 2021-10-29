using System.Collections.Generic;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IPrivacyFlagTypeRepository
    {
        List<PrivacyFlagType> GetMandatoryList();
    }
}
