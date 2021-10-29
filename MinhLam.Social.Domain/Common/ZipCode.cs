using MinhLam.Framework;
using System.Text.RegularExpressions;

namespace MinhLam.Social.Domain.Common
{
    public class ZipCode : ValueObject<ZipCode>
    {
        protected ZipCode()
        {
        }

        public string Value { get; protected set; }

        public static ZipCode New(string zipCode)
        {
            if (Regex.IsMatch(zipCode, @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$") == false)
            {
                throw new DomainException(
                    CommonExceptionCodes.ZipCodeUSInvalid,
                    "Zip code invalud US format");
            }

            return new ZipCode(zipCode);
        }

        protected override bool EqualsCore(ZipCode other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        private ZipCode(string zipCode)
        {
            Value = zipCode;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
