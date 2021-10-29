using MinhLam.Framework;
using System;
using System.Text.RegularExpressions;

namespace MinhLam.Social.Domain.Memberships
{
    public class Username : ValueObject<Username>
    {
        public static Username New(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new DomainException(MembershipExceptionCodes.UsernameIsBlank, "Username cannot empty");
            }

            if (Regex.IsMatch(username, "^[a-zA-Z0-9.]{6,30}") == false)
            {
                throw new DomainException(MembershipExceptionCodes.UserNameIsNotCorrectFormat,
                    "Your username must be at least 6 letters or numbers and no more than 30.");
            }

            return new Username(username);
        }

        internal Username(string username)
        {
            Value = username;
        }

        protected Username()
        {
        }

        public string Value { get; protected set; }

        protected override bool EqualsCore(Username other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
