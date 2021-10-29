using MinhLam.Social.Domain.Common;

namespace MinhLam.Social.Presentors.Memberships
{
    public interface IEditAccountView
    {
        void LoadCurrentInformation(SharedAccountProfile currentUserInfo);
        void ShowMessage(bool success, string message, string userName);
    }
}
