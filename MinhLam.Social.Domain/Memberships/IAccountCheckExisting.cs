namespace MinhLam.Social.Domain.Memberships
{
    public interface IAccountCheckExisting
    {
        bool ExistWithUserName(string username);
        bool ExistWithEmail(string email);
    }
}
