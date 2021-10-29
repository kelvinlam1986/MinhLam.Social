using MinhLam.Social.Application.Memberships;

namespace MinhLam.Social.Presentors.Memberships
{
    public interface IRegisterView
    {
        void ShowErrorMessage(string message);
        void ShowAccountCreatedPanel();
        void ShowCreateAccountPanel();
        void ToggleWizardIndex(int index);
        void LoadTerms(GetCurrentTermReadModel term);
        void LoadreCaptchaSetting(bool value);
        void LoadEmailAddressFromFriendInvitation(string email);
    }
}
