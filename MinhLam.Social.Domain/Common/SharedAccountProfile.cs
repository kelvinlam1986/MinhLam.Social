using System;

namespace MinhLam.Social.Domain.Common
{
    public class SharedAccountProfile
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public bool EmailVerified { get; private set; }
        public string BirthDate { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ZipCode { get; private set; }
        public Guid ProfileId { get; set; }

        public SharedAccountProfile(
            Guid id,
            string username, 
            string email, 
            bool emailVerified,
            string birthDate,
            string firstName,
            string lastName,
            string zipCode,
            Guid profileId
            )
        {
            Id = id;
            UserName = username;
            Email = email;
            EmailVerified = emailVerified;
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
            ZipCode = zipCode;
            ProfileId = profileId;
        }

    }
}
