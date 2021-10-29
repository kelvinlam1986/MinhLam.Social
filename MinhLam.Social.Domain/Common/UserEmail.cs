using MinhLam.Framework;
using System.Text.RegularExpressions;

namespace MinhLam.Social.Domain.Common
{
    public class UserEmail : ValueObject<UserEmail>
    {
        protected UserEmail()
        {
        }

        public string Value { get; protected set; }

        public static UserEmail New(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new DomainException(CommonExceptionCodes.EmailIsEmpty, "Email cannot empty");
            }

            if (Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") == false)
            {
                throw new DomainException(CommonExceptionCodes.EmailIsNotCorrectFormat, "Invalid email format");
            }

            return new UserEmail(email);
        }

        internal UserEmail(string email)
        {
            Value = email;
        }

        protected override bool EqualsCore(UserEmail other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
