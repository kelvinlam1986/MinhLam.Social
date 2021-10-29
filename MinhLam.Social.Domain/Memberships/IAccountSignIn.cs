namespace MinhLam.Social.Domain.Memberships
{
    public interface IAccountSignIn
    {
        void Execute(string username, string password);
    }
}
