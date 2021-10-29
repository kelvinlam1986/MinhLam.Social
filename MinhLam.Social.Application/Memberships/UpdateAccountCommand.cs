namespace MinhLam.Social.Application.Memberships
{
    public class UpdateAccountCommand
    {
        public UpdateAccountCommand(
            string oldPassword,
            string newPassword,
            string username,
            string firstName,
            string lastName,
            string email,
            string zipCode,
            string birthDate)
        {
            this.OldPassword = oldPassword;
            this.NewPassword = newPassword;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.ZipCode = zipCode;
            this.BirthDate = birthDate;
        }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string BirthDate { get; set; }
    }
}
