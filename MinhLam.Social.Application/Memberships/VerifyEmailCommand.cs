namespace MinhLam.Social.Application.Memberships
{
    public class VerifyEmailCommand
    {
        public VerifyEmailCommand(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
