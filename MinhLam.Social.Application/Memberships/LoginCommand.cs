namespace MinhLam.Social.Application.Memberships
{
    public class LoginCommand
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
