namespace MinhLam.Social.Application.Memberships
{
    public class RecoverPasswordCommand
    {
        public RecoverPasswordCommand(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }
    }
}
