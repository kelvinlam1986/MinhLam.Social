using MinhLam.Social.Domain.Memberships;
using MinhLam.Social.Domain.Profiles;
using System;

namespace MinhLam.Social.Infrastructure.Profiles
{
    public class CurrentUserSession : ICurrentUserSession
    {
        public IAccountRepository accountRepository;

        public CurrentUserSession(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Guid GetAccountIdByUsername(string username)
        {
            var account = this.accountRepository.GetAccountByUsername(username);
            if (account == null)
            {
                return Guid.Empty;
            }

            return account.Id;
        }
    }
}
