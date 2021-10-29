using MinhLam.Social.Guide.Domain.Exceptions;
using MinhLam.Social.Guide.Framework;

namespace MinhLam.Social.Guide.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public static Address New(string street, string state, string city)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new DomainException(DomainExceptionCodes.AddressStreetIsEmtpy, "Address is emtpty now");
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                throw new DomainException(DomainExceptionCodes.AddressStateIsEmpty, "Address state is empty now");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new DomainException(DomainExceptionCodes.AddressCityIsEmpty, "Address city is empty now");
            }

            return new Address(street, state, city);
        }

        private Address(string street, string state, string city)
        {
            Street = street;
            State = state;
            City = city;
        }

        protected override bool EqualsCore(Address other)
        {
            return Street == other.Street
                && State == other.State
                && City == other.City;
        }

        protected override int GetHashCodeCore()
        {
            return Street.GetHashCode() + State.GetHashCode() + City.GetHashCode();
        }
    }
}
