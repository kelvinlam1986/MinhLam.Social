namespace MinhLam.Social.Domain.Common
{
    public interface IUserSession
    {
        bool IsLoggedIn { get; set; }
        string Username { get; set; }
        SharedAccountProfile CurrentUser { get; set; }
    }
}
