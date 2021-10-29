using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Memberships;

namespace MinhLam.Social.Presentors.Profiles
{
    public interface IProfileView
    {
        void DisplayInfo(GetCurrentAccountReadModel accountDisplay);
        void pnlPrivacyAccountInfoVisible(bool value);
        void pnlPrivacyIMVisible(bool value);
        void pnlPrivacyTankInfoVisible(bool value);

    }
}
