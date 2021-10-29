using MinhLam.Framework;
using System;
using System.Globalization;

namespace MinhLam.Social.Domain.Common
{
    public class BirthDate : ValueObject<BirthDate>
    {
        public static DateTime EmptyValue = DateTime.MinValue;

        protected BirthDate()
        {
        }

        public DateTime Value { get; protected set; }

        public static BirthDate NewBirthDateFromStringFormatMMDDYYY(string dateString)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(
                dateString, 
                "MM/dd/yyyy", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateValue) == false) {

                throw new DomainException(
                    CommonExceptionCodes.BirthDateIsNotCorrectFormat,
                    "Your birthdate is not correct format (MM/DD/YYYY)");
            }

            return new BirthDate(dateValue);
        }

        protected override bool EqualsCore(BirthDate other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        private BirthDate(DateTime birthDate)
        {
            Value = birthDate;
        }

        public string ToMMDDYYYYString()
        {
            if (Value == null)
            {
                return string.Empty;
            }

            if (Value == BirthDate.EmptyValue)
            {
                return string.Empty;
            }

            return String.Format("{0:MM/dd/yyyy}", Value);
        }

    }
}
