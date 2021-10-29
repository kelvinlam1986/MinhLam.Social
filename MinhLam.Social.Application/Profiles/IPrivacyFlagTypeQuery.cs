using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface IPrivacyFlagTypeQuery
    {
        List<GetPrivacyFlagTypeListReadModel> GetPrivacyFlagTypes();
        List<GetPrivacyFlagTypeListReadModel> GetMandatoryPrivacyFlagTypes();
    }
}
