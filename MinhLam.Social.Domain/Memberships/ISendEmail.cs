namespace MinhLam.Social.Domain.Memberships
{
    public interface ISendEmail
    {
        void SendVerificationEmail(string username, string emailAddress);
        void SendPasswordReminder(string email, string password, string username);
    }
}
