using MinhLam.Framework;
using MinhLam.Social.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Social.Domain.Memberships
{
    public class Account : AggregateRoot
    {
        public Username UserName { get; protected set; }
        public HashedPassword Password { get; protected set; }
        public UserEmail Email { get; protected set; }
        public bool EmailVerified { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public BirthDate BirthDate { get; protected set; }
        public ZipCode ZipCode { get; private set; }
        public Guid TermId { get; private set; }

        [ForeignKey("TermId")]
        public Term CurrentTerm { get; private set; }

        public DateTime CreatedDate { get; protected set; }
        public DateTime LastUpdated { get; protected set; }

        // public List<AccountPermission> Permissions { get; protected set; }
        public virtual ICollection<Permission> Permissions { get; protected set; }

        public static Account NewForRegisterAcount(
            Username username,
            Password password,
            UserEmail email,
            string firstName,
            string lastName,
            BirthDate birthDate,
            ZipCode zipCode,
            Guid termId,
            IAccountCheckExisting accountCheckExisting,
            ITermCheckExisting termCheckExisting,
            IPermissionDefault permissionDefault)
        {
           
            if (username == null)
            {
                throw new DomainException(MembershipExceptionCodes.UsernameIsNull, "Username cannot be null");
            }

            if (password == null)
            {
                throw new DomainException(MembershipExceptionCodes.PasswordIsNull, "Password cannot be null");
            }

            if (email == null)
            {
                throw new DomainException(MembershipExceptionCodes.EmailIsNull, "Email cannot be null");
            }

            if (accountCheckExisting.ExistWithEmail(email.Value))
            {
                throw new DomainException(MembershipExceptionCodes.UserAlreadyExistWithEmail,
                    $"User already exist with email {email.Value}");
            }

            if (accountCheckExisting.ExistWithUserName(username.Value))
            {
                throw new DomainException(MembershipExceptionCodes.UserAlreadyExistWithUserName, 
                    $"User already exist with username {username}");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException(MembershipExceptionCodes.FirstNameIsBlank,
                    "First Name is empty");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException(MembershipExceptionCodes.LastNameIsBlank,
                    "Last Name is empty");
            }

            if (birthDate == null)
            {
                throw new DomainException(MembershipExceptionCodes.BirthDateIsNull,
                    "Birthdate cannot be null");
            }

            if (zipCode == null)
            {
                throw new DomainException(MembershipExceptionCodes.ZipCodeIsNull,
                    "Zipcode cannot be null");
            }

            if (termCheckExisting.Execute(termId) == false)
            {
                throw new DomainException(MembershipExceptionCodes.TermNotFound,
                    $"Cannot found term with id {termId}");
            }

            var defaultPermission = permissionDefault.GetPermissionForNewAccount();
            if (defaultPermission == null)
            {
                throw new DomainException(MembershipExceptionCodes.DefaultPublicPermissionMissing,
                    $"Cannot find default permission for register account");
            }

            var hashedPassword = HashedPassword.NewFromOriginalPassword(password, username.Value);
            var newAccount = new Account(username, hashedPassword, email, firstName, lastName, birthDate, zipCode, termId);
            newAccount.AddPermission(defaultPermission);
            return newAccount;
        }

        internal Account(
            Username username, 
            HashedPassword password, 
            UserEmail email,
            string firstName,
            string lastName,
            BirthDate birthDate,
            ZipCode zipCode,
            Guid termId)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ZipCode = zipCode;
            TermId = termId;
            EmailVerified = false;
            CreatedDate = DateTime.Now;
            LastUpdated = DateTime.Now;
            Permissions = new List<Permission>();
        }

        protected Account()
        {
        }

        public void VerifyEmail()
        {
            if (Id == Guid.Empty || string.IsNullOrWhiteSpace(UserName.Value) || string.IsNullOrWhiteSpace(Email.Value))
            {
                throw new DomainException(MembershipExceptionCodes.UserNotFound, "User not found");
            }

            EmailVerified = true;
        }

        public void UpdateAccount(
            Password oldPassword, 
            Username username, 
            UserEmail email, 
            Password newPassword,
            string firstName,
            string lastName,
            BirthDate birthDate,
            ZipCode zipCode,
            IAccountCheckExisting accountCheckExisting)
        {
            if (username == null)
            {
                throw new DomainException(MembershipExceptionCodes.UsernameIsNull, "Username cannot be null");
            }

            if (email == null)
            {
                throw new DomainException(MembershipExceptionCodes.UsernameIsNull, "Email cannot be null");
            }

            if (oldPassword == null)
            {
                throw new DomainException(MembershipExceptionCodes.PasswordIsNull, "Old Password cannot be null");
            }

            if (newPassword == null)
            {
                throw new DomainException(MembershipExceptionCodes.PasswordIsNull, "New Password cannot be null");
            }

            if (Id == Guid.Empty || string.IsNullOrWhiteSpace(UserName.Value) || string.IsNullOrWhiteSpace(Email.Value))
            {
                throw new DomainException(MembershipExceptionCodes.UserNotFound, "User not found");
            }

            var oldHashedPassword = HashedPassword.NewFromOriginalPassword(oldPassword, this.UserName.Value);
            if (oldHashedPassword != Password)
            {
                throw new DomainException(
                    MembershipExceptionCodes.OldPasswordNotMatchEnterPassword,
                    "The password you entered doesn't match your current password");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException(MembershipExceptionCodes.FirstNameIsBlank,
                    "First Name is empty");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException(MembershipExceptionCodes.LastNameIsBlank,
                    "Last Name is empty");
            }

            if (birthDate == null)
            {
                throw new DomainException(MembershipExceptionCodes.BirthDateIsNull,
                    "Birthdate cannot be null");
            }

            if (zipCode == null)
            {
                throw new DomainException(MembershipExceptionCodes.ZipCodeIsNull,
                    "Zipcode cannot be null");
            }

            if (Email != email)
            {
                if (accountCheckExisting.ExistWithEmail(email.Value) == false)
                {
                    Email = email;
                    EmailVerified = false;
                }
                else
                {
                    throw new DomainException(
                        MembershipExceptionCodes.UserAlreadyExistWithEmail,
                        $"User already exist with email {email.Value}");
                }
            }

            if (newPassword.IsEmptyPassword() == false)
            {
                var hashedPassword = HashedPassword.NewFromOriginalPassword(newPassword, username.Value);
                Password = hashedPassword;
            }

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ZipCode = zipCode;
            LastUpdated = DateTime.Now;
        }

        private void AddPermission(Permission permission)
        {
            Permissions.Add(permission);
        }
    }
}
