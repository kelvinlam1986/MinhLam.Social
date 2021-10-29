using System;

namespace MinhLam.Social.Guide.Domain.Exceptions
{
    public class BadCredentialException : Exception
    {
        public BadCredentialException(string message) : base(message)
        {
        }
    }
}
