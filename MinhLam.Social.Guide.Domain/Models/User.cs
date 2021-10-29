using MinhLam.Social.Guide.Domain.Exceptions;
using MinhLam.Social.Guide.Domain.ValueObjects;
using MinhLam.Social.Guide.Framework;

namespace MinhLam.Social.Guide.Domain.Models
{
    public class User : AggregateRoot
    {
        public string UserName { get; protected set; }
        public Address Address { get; protected set; }

        protected User()
        {
        }

        public User(string username)
        {
            this.UserName = username;
        }

        public void SetAddress(Address address)
        {
            if (address == null)
            {
                throw new DomainException(DomainExceptionCodes.AddressIsEmpty, "Address is empty");
            }

            this.Address = address;
        }
    }
}
