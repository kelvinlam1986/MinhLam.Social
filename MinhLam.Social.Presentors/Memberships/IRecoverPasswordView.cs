namespace MinhLam.Social.Presentors.Memberships
{
    public interface IRecoverPasswordView
    {
        void ShowMessage(string message);
        void ShowRecoverPasswordPanel(bool isVisible);
    }
}
