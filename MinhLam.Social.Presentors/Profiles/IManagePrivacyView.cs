using MinhLam.Social.Application.Profiles;
using System.Collections.Generic;

namespace MinhLam.Social.Presentors.Profiles
{
    public interface IManagePrivacyView
    {
        void ShowMessage(string message);
        void ShowPrivacyTypes(
            List<GetPrivacyFlagTypeListReadModel> privacyFlagTypes,
            List<GetVisibilityListReadModel> visibilies,
            List<GetPrivacyFlagListByProfileReadModel> privacyFlags);
    }
}
