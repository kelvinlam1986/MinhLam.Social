using MinhLam.Social.Guide.Domain.DomainServices;
using MinhLam.Social.Guide.Domain.Exceptions;
using MinhLam.Social.Guide.Domain.Models;
using MinhLam.Social.Guide.Domain.Repositories;
using System;

namespace MinhLam.Social.Guide.Infrastructure.DomainServices
{
    public class DefaultEncryptionSignIn : ISignIn
    {
        private readonly IUserRepository userRepository;

        public DefaultEncryptionSignIn(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Execute(string username, string password)
        {
            if (this.userRepository.Has(username))
            {
                throw new ArgumentException($"The user {username} does not exist.");
            }

            var user = this.userRepository.ByUserName(username);
            if (!this.IsPasswordValidForUser(user, password))
            {
                throw new BadCredentialException("Your username and password not matched.");
            }

            return user;
        }

        private bool IsPasswordValidForUser(User user, string unEncryptPassword)
        {
            return true;
        }
    }
}
