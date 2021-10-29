using MinhLam.Framework;

namespace MinhLam.Social.Domain.Memberships
{
    public class HashedPassword : ValueObject<HashedPassword>
    {
        public string Value { get; protected set; }

        public static HashedPassword NewFromOriginalPassword(Password password, string username)
        {
            var hashedPassword = password.Value.Encrypt(username);
            return new HashedPassword(hashedPassword);
        }

        protected HashedPassword()
        {
        }

        internal HashedPassword(string value)
        {
            Value = value;
        }

        protected override bool EqualsCore(HashedPassword other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
