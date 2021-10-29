using MinhLam.Framework;

namespace MinhLam.Social.Domain.Profiles
{
    public class TankYear : ValueObject<TankYear>
    {
        public int Value { get; protected set; }

        public TankYear()
        {
        }

        public static TankYear New(int year)
        {
            if (year < 1900 && year > 2099)
            {
                throw new DomainException(
                    ProfileExceptionCodes.TankYearOutOfRange,
                    "Tank year should be between 1900 and 2099");
            }

            return new TankYear(year);
        }

        internal TankYear(int year)
        {
            Value = year;
        }

        protected override bool EqualsCore(TankYear other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
