using MinhLam.Framework;
using System.Text.RegularExpressions;

namespace MinhLam.Social.Domain.Memberships
{
    public class Password : ValueObject<Password>
    {
        public static readonly Password EmptyPassword = new Password(string.Empty);
        protected Password()
        {
        }

        public string Value { get; protected set; }

        public static Password NewFromOriginal(string password, bool checkEmpty = true, bool checkFormat = true)
        {
            if (checkEmpty)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new DomainException(MembershipExceptionCodes.PasswordIsBlank, "Password cannot empty");
                }
            }
         
            if (checkFormat)
            {
                if (Regex.IsMatch(password, @"(?=^.{5,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$") == false)
                {
                    throw new DomainException(MembershipExceptionCodes.PasswordIsNotCorrectFormat, "Password is invalid format");
                }

            }

            return new Password(password);
        }
        
        internal Password(string password)
        {
            Value = password;
        }

        public bool IsEmptyPassword()
        {
            return Value == string.Empty;
        }

        protected override bool EqualsCore(Password other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }
    }
}
