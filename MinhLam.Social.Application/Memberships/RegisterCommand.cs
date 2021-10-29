using System;

namespace MinhLam.Social.Application.Memberships
{
    public class RegisterCommand
    {
        public RegisterCommand(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            string birthDate,
            string zipCode,
            string termId)
        {
            this.UserName = username;
            this.Password = password;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.ZipCode = zipCode;
            this.TermId = termId;
        }

        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string BirthDate { get; protected set; }
        public string ZipCode { get; private set; }
        public string TermId { get; private set; }
    }
}
